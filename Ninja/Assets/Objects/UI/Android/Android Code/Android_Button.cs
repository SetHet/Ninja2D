using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Android_Button
{
    #region Variables
    [SerializeField] protected Button button;
    [SerializeField] protected Color click = Color.gray;
    #endregion

    #region Methods
    public bool isDown()
    {
        return false;
    }
    public bool isUp()
    {
        return false;
    }
    public bool isPress()
    {
        return false;
    }
    public bool isClick()
    {
        return false;
    }
    #endregion
}
