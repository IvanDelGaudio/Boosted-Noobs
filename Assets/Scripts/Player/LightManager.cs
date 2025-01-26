using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    #region Public Variables
    public Renderer button1;
    public Renderer button2;
    public Renderer button3;
    public Material material;
    public AnimationDoorController controller;
    #endregion
    #region Private Variables
    [NonSerialized]
    public bool button1bool;
    [NonSerialized]
    public bool button2bool;
    [NonSerialized]
    public bool button3bool;
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods
    private void Update()
    {
        if (button1bool == true && button2bool == true && button3bool == true)
        {
            controller.SetTrueStateOfTheDoor();
        }
    }
    public void ChangeColorButton1()
    {
        button1.material=material;
        button1bool=true;
    }
    public void ChangeColorButton2()
    {
        button2.material = material;
        button2bool = true;
    }
    public void ChangeColorButton3()
    {
        button3.material = material;
        button3bool = true;
    }
    #endregion
    #region Private Methods
    #endregion
}
