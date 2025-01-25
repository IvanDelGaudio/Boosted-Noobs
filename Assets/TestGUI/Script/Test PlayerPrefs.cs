using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestPlayerRefs : MonoBehaviour
{
    #region Private Variables
    private PlayerPrefsBool playerPrefsBool;
    #endregion

    #region Cycle Life

    private void Start()
    {
        playerPrefsBool = GetComponent<PlayerPrefsBool>();

    }

    void Update()
    {
        if (playerPrefsBool != null)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                playerPrefsBool.SaveBool("ref1", true);
                playerPrefsBool.SaveBool("ref2", false);
                playerPrefsBool.SaveBool("ref3", true);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("ref1: " + playerPrefsBool.LoadBool("ref1"));
                Debug.Log("ref2: " + playerPrefsBool.LoadBool("ref2"));
                Debug.Log("ref3: " + playerPrefsBool.LoadBool("ref3"));
            }
        }
    }

    #endregion
}
