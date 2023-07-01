using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Variables

    public GameObject button;
    public static bool gameIsPaused;

    public GameObject PauseMenuUI;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause_Menu();
            }
        }
    }

    #endregion

    #region Private methods

    private void Pause_Menu()
    {
        button.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void Resume()
    {
        button.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    #endregion
}