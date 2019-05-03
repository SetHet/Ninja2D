using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Android_Button
{
    #region Variables
    [SerializeField] protected EventTrigger trigger;
    [SerializeField] protected Color click = Color.gray;
    [SerializeField] protected bool isCircle = true;
    [SerializeField] protected float dilay_down = 0.05f;
    float cooldown_down = 0f;

    bool isDown = false;
    bool isUp = false;
    bool isPress = false;
    bool isClick = false;
    #endregion

    #region Methods
    public bool IsDown()
    {
        if (isDown)
        {
            isDown = false;
            return true;
        }
        return false;
    }
    public bool IsUp()
    {
        return isUp;
    }
    public bool IsPress()
    {
        Debug.Log("El tiene un bug, hay que ver como cambiar su sistema para que se active mientas se mantenga precionado");
        return isPress;
    }
    public bool IsClick()
    {
        return isClick;
    }

    public void ConfigEvent()
    {
        AddEvent(EventTriggerType.PointerDown, (data) => { isDown = true; cooldown_down = Time.time + dilay_down; isPress = true; });
        AddEvent(EventTriggerType.PointerUp, (data) => { isUp = true; isPress = false; });
        AddEvent(EventTriggerType.PointerExit, (data) => { isPress = false; });
        AddEvent(EventTriggerType.PointerClick, (data) => { isClick = true; });
    }

    public void Reset()
    {
        if (Time.time > cooldown_down)
            isDown = false;
        isUp = false;
        isClick = false;
    }

    void AddEvent(EventTriggerType triggerType, UnityEngine.Events.UnityAction<BaseEventData> method)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = triggerType;
        entry.callback.AddListener(method);
        trigger.triggers.Add(entry);
    }

   
    #endregion
}
