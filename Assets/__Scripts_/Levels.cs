using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    #region Public methods

    public void BackPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level1Pressed()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    #endregion
}