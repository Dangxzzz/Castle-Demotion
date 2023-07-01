using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    Idle,
    Playing,
    LevelEnd,
}

public class MissionDemotion : MonoBehaviour
{
    #region Variables

    public GameObject castle;
    public Vector3 castlePos;
    public GameObject[] castles;

    [Header("Set Dynamically")]
    public static int level;
    public int levelMax;
    public GameMode mode = GameMode.Idle;
    public int shotsTaken;
    public string showing = "Show Slingshot";
    public TextMeshProUGUI uitBotton;
    [Header("Set in Inspector")]
    public TextMeshProUGUI uitLevel;
    public TextMeshProUGUI uitShots;
    private static MissionDemotion _missionDemotion;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }

        PlayerPrefs.SetInt("Level", level);
    }

    private void Start()
    {
        _missionDemotion = this;
        levelMax = castles.Length;
        StartLevel();
    }

    private void Update()
    {
        if (level > PlayerPrefs.GetInt("Level"))
        {
            PlayerPrefs.SetInt("Level", level);
        }

        UpdateGUI();
        if (mode == GameMode.Playing && Goal.goalMelt)
        {
            mode = GameMode.LevelEnd;
            SwitchView("Show Both");
            Invoke("NextLevel", 2f);
        }
    }

    #endregion

    #region Public methods

    public static void ShotFired()
    {
        _missionDemotion.shotsTaken++;
    }

    public void PrevLevelPressed()
    {
        level--;
        if (level < 0)
        {
            level = 0;
        }

        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene("_Scene_0");
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitBotton.text;
        }

        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.poi = null;
                uitBotton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.poi = _missionDemotion.castle;
                uitBotton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.poi = GameObject.Find("ViewBoth");
                uitBotton.text = "Show Slingshot";
                break;
        }
    }

    #endregion

    #region Private methods

    private void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            SceneManager.LoadScene("BonusScene");
            level = 0;
        }

        StartLevel();
    }

    private void StartLevel()
    {
        if (castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        SwitchView("Show Both");
        ProjectileLine.projectileLine.Clear();

        Goal.goalMelt = false;
        UpdateGUI();

        mode = GameMode.Playing;
    }

    private void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    #endregion
}