using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    #region Public Variables
    public LightManager button;
    public Material MaterialGreenButton;
    public AnimationButton aniButton;
    public Text text;
    #endregion
    #region Private Variables
    private bool playerInRange=false;
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods


    private void Update()
    {
        ActiveButtonAnimation();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = "Press E";
            playerInRange = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            aniButton.SetTrueAnimationbutton();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        if (other.gameObject.CompareTag("Player"))
            {
                playerInRange = false;
            }
        
    }
    private void ActiveButtonAnimation()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            aniButton.SetTrueAnimationbutton();
            button.ChangeColorButton1();
        }
    }

    #endregion
    #region Private Methods
    #endregion
}
