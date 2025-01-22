using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using S = System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[DisallowMultipleComponent]
public class Player3D : MonoBehaviour
{
    #region Public variables
    public float moveVelocity;
    public float rotationVelocity;
    #endregion
    #region Private variables
    private CharacterController characterController;
    #endregion
    #region Lifecycle
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical");

        float h = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(h, 0, v) * moveVelocity * Time.deltaTime;
        characterController.Move(move);


    }

    #endregion
    #region Public methods



    #endregion
    #region Private methods
    #endregion

}

