using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    #region Variables

    public AudioMixer am;
    private bool isFullScreen;

    #endregion

    #region Public methods

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    #endregion
}