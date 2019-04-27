﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidControl : MonoBehaviour
{
    #region UI
    [SerializeField] protected Android_DinamicStick stickLeft;
    [SerializeField] protected Android_Button attack;
    [SerializeField] protected Android_Button jump;
    #endregion
    private void Start()
    {
        if (!OnlyAndroid()) return;
        attack.ConfigEvent();
        jump.ConfigEvent();
        stickLeft.Init();
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
        attack.Reset();
        jump.Reset();
    }

    bool OnlyAndroid()
    {
#if !(UNITY_ANDROID || UNITY_EDITOR)
            Destroy(gameObject);
            return false;
#endif
        return true;
    }

    public void Test()
    {
        Debug.Log("Is Press");
    }
}
