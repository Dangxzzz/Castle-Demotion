using UnityEngine;
using UnityEngine.UI;

public class SaveSlider : MonoBehaviour
{
    #region Variables

    [Header("Tags")]
    [SerializeField] public string sliderTag;
    [Header("Components")]
    [SerializeField] private Slider slider;

    [Header("Keys")]
    [SerializeField] private string saveValueKey;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        slider.value = PlayerPrefs.GetFloat(saveValueKey);
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat(saveValueKey, slider.value);
    }

    #endregion
}