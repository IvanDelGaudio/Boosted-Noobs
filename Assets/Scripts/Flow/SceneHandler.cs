using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneHandler : MonoBehaviour
{
    #region Private Variables
    private LoadSceneMode loadMode = LoadSceneMode.Single; // Mode of scene loading
    AsyncOperation currentSceneLoad = null;
    private SceneData sceneData;

    #endregion

    #region Public Methods
    public void LoadScene(string address)
    {
        currentSceneLoad = SceneManager.LoadSceneAsync(address, loadMode);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }
    public void ClearPlayerRefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear Refs");
    }
    #endregion

    #region Private Methods

    #endregion
}
