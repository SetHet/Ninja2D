using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidControl : MonoBehaviour
{
    #region UI
    public RectTransform stick_limits;
    public RectTransform stick_area;
    public RectTransform stick_point;

    public Button attack;
    public Button jump;
    #endregion
    private void Start()
    {
        if (!OnlyAndroid()) return;
    }

    void Update()
    {
        
    }

    bool OnlyAndroid()
    {
#if !(UNITY_ANDROID || UNITY_EDITOR)
            Destroy(gameObject);
            return false;
#endif
        return true;
    }
}
