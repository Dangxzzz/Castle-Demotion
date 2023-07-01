using TMPro;
using UnityEngine;

public class SaveDropDown : MonoBehaviour
{
    #region Variables

    [Header("Tags")]
    [SerializeField] public string dropDownTag;
    [Header("Components")]
    [SerializeField] private TMP_Dropdown dropDown;

    [Header("Keys")]
    [SerializeField] private string saveValueKey;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        dropDown.value = PlayerPrefs.GetInt(saveValueKey);
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat(saveValueKey, dropDown.value);
    }

    #endregion
}