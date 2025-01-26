using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestGameOver : MonoBehaviour
{
    #region Public Variables
    public GameManager gameManager;
    #endregion

    #region Cycle Life

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameManager.GameOver();
        }
    }

    #endregion
}