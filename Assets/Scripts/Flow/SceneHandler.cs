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
    #endregion

    #region Private Methods

    #endregion
}
