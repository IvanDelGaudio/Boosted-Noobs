using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SFX))]
public class ButtonCheck : MonoBehaviour
{
    #region Public Variables
    public Text text;
    public AnimationDoorController anim;
    public Material material;
    public AnimationButton animButton;

    #endregion
    #region Private Variables
    [SerializeField]
    private bool playerInRange;
    private bool finischedSound;
    private SFX sfx_;
    [SerializeField]
    private Light light;
    [SerializeField]
    private Renderer button;

    #endregion
    #region Lifecycle
    private void Start()
    {
        text.text = null;
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
            text.text = "Press E";
            Debug.Log("Player has enter");
            playerInRange = true;
        }
    }   

        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = "";
            Debug.Log("Player has exit");
            playerInRange = false;
        }
    }
    private void activeSound()
    {
        if (playerInRange && Input.GetKeyUp(KeyCode.E) && finischedSound==false)
        {
            animButton.SetTrueAnimationbutton();
            sfx_.PlaySFX(0);
            finischedSound = true;
        }

    }

    private void checkEndTheSong()
    {
        if (sfx_.audioSource==null && finischedSound == true)
        {
            Debug.Log("sei un coglione");
            anim.SetTrueStateOfTheDoor();
            light.color = Color.green;
            button.material = material;
        }
    }
    #endregion
}
