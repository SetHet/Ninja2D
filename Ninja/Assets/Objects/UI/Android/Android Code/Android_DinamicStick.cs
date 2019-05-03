using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Android_DinamicStick
{
    #region Variables
    CanvasScaler canvas;
    [SerializeField] protected RectTransform Area;
    [SerializeField] protected RectTransform Circle;
    [SerializeField] protected RectTransform Point;

    [SerializeField] protected Vector2 OriginPoint;
    [SerializeField] protected bool fixAxis = false;
    [SerializeField] protected bool fixIntervaloLimit = true; // si el axis dependera del punto muerto y maximo
    [SerializeField] protected bool isDinamic = true;
    [SerializeField] protected bool resetInUp = true;
    [SerializeField] protected bool manualRadio = true;
    [SerializeField] protected float manualRadioValue = 40f;
    [Range(0f, 1f)] [SerializeField] protected float puntoMuerto = 0f;
    [Range(0f, 1f)] [SerializeField] protected float puntoMaximo = 1f;
    #endregion

    #region Methods
    public void Init()
    {
        canvas = Area.GetComponentInParent<CanvasScaler>();
        Config_Rect();
        Config_Trigger();
    }

    public Vector2 GetAxis()
    {
        Vector2 vec = new Vector2();

        vec = Point.localPosition - Circle.localPosition;
        if (manualRadio)
        {
            vec = vec / manualRadioValue;
        }
        else
        {
            vec = vec / (Circle.rect.height / 2f);
        }

        if (vec.magnitude < puntoMuerto) return Vector2.zero;
        if (vec.magnitude > puntoMaximo) return vec.normalized;
        if (fixAxis) return vec.normalized;

        if (fixIntervaloLimit)
        {
            vec.x = Utilities.UtilitiesMath.RemapFloat(vec.x, puntoMuerto, puntoMaximo);
            vec.y = Utilities.UtilitiesMath.RemapFloat(vec.y, puntoMuerto, puntoMaximo);
        }

        return vec;
    }

    public void Reset()
    {
        Circle.anchoredPosition = OriginPoint;
        Point.anchoredPosition = OriginPoint;
    }

    void Up()
    {
        if (resetInUp) Reset();
    }

    void Drag(PointerEventData data)
    {
        Vector2 pos = data.position;
        pos *= canvas.referenceResolution.y/((float)Screen.height);
        Move(pos);
    }
    
    void Config_Trigger()
    {
        EventTrigger trigger = Point.gameObject.GetComponent<EventTrigger>();
        if (trigger == null) trigger = Point.gameObject.AddComponent<EventTrigger>();

        
        AddEvent(trigger, EventTriggerType.PointerUp, (data) => Up());
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

    void Move(Vector2 pos)
    {
        Point.localPosition = new Vector3(pos.x, pos.y - Area.rect.height / 2, 0);
        Vector2 dif = Point.localPosition - Circle.localPosition;
        float radio = Circle.rect.height / 2f;
        if (manualRadio) radio = manualRadioValue;
        if (dif.magnitude <= radio) return;
        if (isDinamic)
        {
            Vector2 position_circle = Point.localPosition - (Vector3)dif.normalized * radio;
            if (position_circle.x-radio < 0)
            {
                position_circle.x = radio;
            }
            else if (position_circle.x + (radio) > Area.rect.width)
            {
                position_circle.x = Area.rect.width - radio;
            }

            if (position_circle.y - radio < -Area.rect.height/2f)
            {
                position_circle.y = -Area.rect.height / 2f + radio;
            }
            else if (position_circle.y + radio > Area.rect.height / 2f)
            {
                position_circle.y = Area.rect.height / 2f - radio;
            }
            Circle.localPosition = position_circle;
            Point.localPosition = Circle.localPosition + (Vector3)dif.normalized * radio;
        }
        else
        {
            Point.localPosition = Circle.localPosition + (Vector3)dif.normalized * radio;
        }
    }
    
    #endregion

}
