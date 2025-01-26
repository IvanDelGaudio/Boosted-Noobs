using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerPrefsBool : MonoBehaviour
{
    #region Public Method
    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }


    public bool LoadBool(string key)
    {
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
    #endregion
}
