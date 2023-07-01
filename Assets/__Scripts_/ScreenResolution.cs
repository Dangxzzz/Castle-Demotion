using TMPro;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    #region Variables

    public TMP_Dropdown DropDown;

    #endregion

    #region Public methods

    public void DropDownFun()
    {
        if (DropDown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }

        if (DropDown.value == 1)
        {
            Screen.SetResolution(1280, 1024, true);
        }

        if (DropDown.value == 2)
        {
            Screen.SetResolution(1024, 678, true);
        }
    }

    #endregion
}