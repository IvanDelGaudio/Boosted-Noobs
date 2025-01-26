using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SFX))]
public class Buttonlevel1 : MonoBehaviour
{
    #region Public Variables
    public LightManager button;
    public Material MaterialGreenButton;
    public AnimationButton aniButton;
    public Text text;
    private SFX sfx;
    #endregion
    #region Private Variables
    private bool playerInRange = false;
    private bool endSound=false;
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods

    private void Start()
    {
        sfx = GetComponent<SFX>();
    }
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
        if (Input.GetKeyUp(KeyCode.E) && playerInRange && endSound==false)
        {
            aniButton.SetTrueAnimationbutton();
            endSound = true;
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
        if (Input.GetKeyUp(KeyCode.E) && playerInRange && endSound==true)
        {
            aniButton.SetTrueAnimationbutton();
            button.ChangeColorButton1();
            sfx.PlaySFX(0);        
        }
    }

    #endregion
    #region Private Methods
    #endregion
}
