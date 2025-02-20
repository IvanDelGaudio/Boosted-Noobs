using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SFX))]
public class ButtonCheck : MonoBehaviour
{
    #region Public Variables
    public GameObject text;
    public KeyCheck key;
    public Material material;
    public AnimationButton animButton;
    #endregion
    #region Private Variables
    [SerializeField]
    private bool playerInRange;
    private bool finishedSound;
    private SFX sfx_;
    [SerializeField]
    private Light light;
    [SerializeField]
    private Renderer button;

    #endregion
    #region Lifecycle
    private void Start()
    {
        
        sfx_ = GetComponent<SFX>();
    }
    #endregion
    #region Public Methods
    private void Update()
    {
        activeSound();
        checkEndTheSong();
    }
    #endregion
    #region Private Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            Debug.Log("Player has enter");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            Debug.Log("Player has exit");
            playerInRange = false;
        }
    }
    private void activeSound()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && finishedSound == false)
        {
            sfx_.PlaySFX(0);
            finishedSound = true;
            animButton.SetTrueAnimationbutton();
        }

    }

    private void checkEndTheSong()
    {
        if (sfx_.audioSource == null && finishedSound == true)
        {
            Debug.Log("sei un coglione");
            light.color = Color.green;
            button.material = material;
            finishedSound = false;
            key.requiredKey = true; 
        }
    }
    #endregion
}