using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestSubtile : MonoBehaviour
{
    #region Public Variables
    public SubManager subManager;
    #endregion

    #region Cycle Life

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            subManager.StartSubtitles(0);

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            subManager.StartSubtitles(1);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            subManager.StopSubtitles();
        }
    }

    #endregion
}
