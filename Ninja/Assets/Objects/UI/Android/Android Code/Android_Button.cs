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

    bool isDown = false;
    bool isUp = false;
    bool isPress = false;
    bool isClick = false;
    #endregion

    #region Methods
    public bool IsDown()
    {
        return isDown;
    }
    public bool IsUp()
    {
        return isUp;
    }
    public bool IsPress()
    {
        return isPress;
    }
    public bool IsClick()
    {
        return isClick;
    }

    public void ConfigEvent()
    {
        AddEvent(EventTriggerType.PointerDown, (data) => { isDown = true; isPress = true; });
        AddEvent(EventTriggerType.PointerUp, (data) => { isUp = true; isPress = false; });
        AddEvent(EventTriggerType.PointerExit, (data) => { isPress = false; });
        AddEvent(EventTriggerType.PointerClick, (data) => { isClick = true; });
    }

    public void Reset()
    {
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
