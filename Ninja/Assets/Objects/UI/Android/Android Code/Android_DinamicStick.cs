using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Android_DinamicStick
{
    #region Variables
    [SerializeField] protected RectTransform Area;
    [SerializeField] protected RectTransform Circle;
    [SerializeField] protected RectTransform Point;

    [SerializeField] protected Vector2 OriginPoint;
    #endregion

    #region Methods
    public Vector2 GetAxis()
    {
        Vector2 vec = new Vector2();
        return vec;
    }
    #endregion

}
