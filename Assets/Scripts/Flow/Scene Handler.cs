using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{

    #region Public variables   
    #endregion
    #region Private variables
    #endregion
    #region Lifecycle       
    #endregion
    #region Public methods    
    public void LoadSingleScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }
    public void LoadLevel(string designNameScene, string logicSceneName)
    {
        string levelName = designNameScene;
        PlayerPrefs.SetString("LevelName", levelName);
        PlayerPrefs.SetString("LogicSceneName", logicSceneName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(designNameScene, LoadSceneMode.Single);
        SceneManager.LoadScene(logicSceneName, LoadSceneMode.Additive);
    }
       
    #endregion
    #region Private methods
    #endregion
}


