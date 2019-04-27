using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Android_DinamicStick
{
    #region Variables
    [SerializeField] protected RectTransform Area;
    [SerializeField] protected RectTransform Circle;
    [SerializeField] protected RectTransform Point;

    [SerializeField] protected Vector2 OriginPoint;
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
        Config_Rect();
        Config_Trigger();
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
        Circle.anchoredPosition = OriginPoint;
        Point.anchoredPosition = OriginPoint;
    }

    void Down()
    {

    }

    void Up()
    {
        if (resetInUp) Reset();
    }

    void Drag(PointerEventData data)
    {

    }

    void Exit()
    {

    }
    
    void Config_Trigger()
    {
        EventTrigger trigger = Point.gameObject.GetComponent<EventTrigger>();
        if (trigger == null) trigger = Point.gameObject.AddComponent<EventTrigger>();

        AddEvent(trigger, EventTriggerType.PointerDown, (data) => Down());
        AddEvent(trigger, EventTriggerType.PointerUp, (data) => Up());
        AddEvent(trigger, EventTriggerType.PointerExit, (data) => Exit());
        AddEvent(trigger, EventTriggerType.Drag, (data) => Drag((PointerEventData)data));
    }

    void AddEvent(EventTrigger trigger, EventTriggerType triggerType, UnityEngine.Events.UnityAction<BaseEventData> method)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = triggerType;
        entry.callback.AddListener(method);
        trigger.triggers.Add(entry);
    }

    void Config_Rect()
    {
        Circle.anchorMin = new Vector2(0, 0);
        Circle.anchorMax = new Vector2(0, 0);

        Point.anchorMin = new Vector2(0, 0);
        Point.anchorMax = new Vector2(0, 0);

        Reset();
    }
    #endregion

}
