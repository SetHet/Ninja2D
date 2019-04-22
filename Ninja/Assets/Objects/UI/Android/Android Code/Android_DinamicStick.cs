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

    protected Vector2 OriginPoint;
    [SerializeField] protected bool fixAxis = false;
    [SerializeField] protected bool fixIntervaloLimit = true; // si el axis dependera del punto muerto y maximo
    [SerializeField] protected bool isDinamic = true;
    [SerializeField] protected bool resetInUp = true;
    [Range(0f, 1f)] [SerializeField] protected float puntoMuerto = 0f;
    [Range(0f, 1f)] [SerializeField] protected float puntoMaximo = 1f;
    #endregion

    #region Methods
    public void Init()
    {
        OriginPoint = Circle.rect.position;
    }

    public Vector2 GetAxis()
    {
        Vector2 vec = new Vector2();

        //calcular Axis

        if (vec.magnitude < puntoMuerto) return Vector2.zero;
        if (vec.magnitude > puntoMaximo) return vec.normalized;
        if (fixAxis) return vec.normalized;

        if (fixIntervaloLimit)
        {
            //calcular valor intermedio 
            //libreria Utility.Math.Remap
        }

        return vec;
    }

    public void Reset()
    {
        if (!resetInUp) return;
    }
    #endregion

}
