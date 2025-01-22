using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestSubtile : MonoBehaviour
{
    #region Public Variables
    public SubManager subManager;
    #endregion

    #region Private Variables

    #endregion

    #region Cycle Life
    void Awake()
    {

    }

    void Start()
    {
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Assuming you have a SubtitleController reference as `subtitleController`
            subManager.StartSubtitles(0); // Start the first phrase

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            // Assuming you have a SubtitleController reference as `subtitleController`
            subManager.StartSubtitles(1); // Start the first phrase

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // To stop
            subManager.StopSubtitles();
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
