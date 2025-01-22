using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    #region Public variables   
    #endregion
    #region Private variables
    private SceneHandler sceneHandler = new SceneHandler();
    #endregion
    #region Lifecycle       
    #endregion
    #region Public methods 
    public void RetryLevel()
    {
        string levelName = PlayerPrefs.GetString("LevelName");
        string logicSceneName = PlayerPrefs.GetString("LogicSceneName");

        if (!string.IsNullOrEmpty(levelName))
        {
            sceneHandler.LoadLevel(levelName, logicSceneName);
        }
    }
    #endregion
    #region Private methods
    #endregion

}
