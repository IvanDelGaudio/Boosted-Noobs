using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRefsHandler : MonoBehaviour
{
    #region Public variables
    public Button targetButton;
    public string[] playerPrefsKeys;
    #endregion

    #region Lifecycle
    void Update()
    {
        CheckExistingPlayRefs();
    }
    #endregion

    #region Public methods
    public void ClearPlayerRefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CheckExistingPlayRefs()
    {
        bool hasAnyKey = false;

        foreach (string key in playerPrefsKeys)
        {
            if (PlayerPrefs.HasKey(key))
            {
                hasAnyKey = true;
                break;
            }
        }

        targetButton.interactable = hasAnyKey;
    }
    #endregion

    #region Private methods
    #endregion

    
}
