using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestLoading : MonoBehaviour
{
    #region Public Variables
    public GameManager gameManager;
    public GameObject loading;
    #endregion

    #region Cycle Life

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.ActivatePanel(loading);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            gameManager.DeactivatePanel(loading);


        }
    }

    #endregion
}