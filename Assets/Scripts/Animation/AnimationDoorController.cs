using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
[RequireComponent(typeof(Animator))]
public class AnimationDoorController : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Animator animator;

    private string animatorOpenDoorName = "Open";
    private int animatorOpenDoor = 0;
    private string animatorStartDoorName = "Start";
    private int animatorStartDoor = 0;
    [Header("Insert the initial state of the door")]
    private bool animatorStart = false;
    public bool controlOpenDoor = false;
    
    private Vector3 originalPosition;
    private float animatedY;
    private bool soundTrig = true;
    private SFX sfx_;
    #endregion

    #region Cycle Life
    private void Start()
    {
        sfx_ = GetComponent<SFX>();
        animatorOpenDoor = Animator.StringToHash(animatorOpenDoorName);
        animatorStartDoor = Animator.StringToHash(animatorStartDoorName);
        originalPosition = transform.position;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateYPosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetFalseDoor();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetTrueStateOfTheDoor();
        }

    }
    #endregion

    #region Private Methods
    private void AnimateYPosition()
    {
        animatedY = animator.GetFloat("AnimatedY");

        transform.position = new Vector3(originalPosition.x, originalPosition.y + animatedY, originalPosition.z);
    }
    public void SetTrueStateOfTheDoor()
    {
        Debug.Log("sono entrato");
        controlOpenDoor = true;
        animator.SetBool(animatorOpenDoorName, controlOpenDoor);
        animator.SetBool(animatorStartDoorName, controlOpenDoor);
        if (soundTrig == true)
        {
            sfx_.PlaySFX(0);
            soundTrig = false;
        }
    }
    public void SetFalseDoor()
    {
        controlOpenDoor = false;
        Debug.Log("sono uscito");
        Debug.Log(animatorOpenDoorName);
        animator.SetBool(animatorOpenDoorName, controlOpenDoor);
        if (soundTrig == false)
        {
            sfx_.PlaySFX(0);
            soundTrig = true;
        }
    }
    #endregion
}
