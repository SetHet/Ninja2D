using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidControl : MonoBehaviour
{
    #region UI
    public Android_DinamicStick stickLeft;
    public Android_Button attack;
    public Android_Button jump;
    #endregion

    #region Singleton
    protected static AndroidControl _instance;
    public static AndroidControl instance { get { return _instance; } }

    void Singleton()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogWarning("Hay varias instancias de AndroidControl.");
            #if UNITY_EDITOR
            gameObject.SetActive(false);
            #else
            Destroy(gameObject);
            #endif
        }
    }
#endregion

#region Basic Methods
    
    private void Awake()
    {
        if (!OnlyAndroid()) return;
        attack.ConfigEvent();
        jump.ConfigEvent();
        stickLeft.Init();
        Singleton();
        Debug.Log("Ready Android Control.");
    }

    private void LateUpdate()
    {
        attack.Reset();
        jump.Reset();
    }

#endregion

#region Methods

    bool OnlyAndroid()
    {
#if !(UNITY_ANDROID || UNITY_EDITOR)
            Destroy(gameObject);
            return false;
#endif
        return true;
    }
    #endregion


}
