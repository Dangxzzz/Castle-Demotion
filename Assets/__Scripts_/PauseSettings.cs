using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSettings : MonoBehaviour
{
    #region Variables

    public static bool gameIsPaused = false;
    public static int level;

    #endregion

    #region Public methods

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }

    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void PrevLevelPressed()
    {
        level--;
        SceneManager.LoadScene("_Scene_0");
        Time.timeScale = 1f;
    }

    #endregion
}