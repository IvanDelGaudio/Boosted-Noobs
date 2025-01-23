using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
[RequireComponent (typeof(Animator))]
public class AnimationDoorUpDown : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    private string animatorOpenDoorName = "Open";
    private int animatorOpenDoor = 0;
    private string animatorStartDoorName = "Start";
    private int animatorStartDoor = 0;
    [Header ("Insert the initial state of the door")]
    private bool animatorStart=false;
    #endregion
    #region Private Variables
    private SFX sfx_;
    private Animator animator;
    private bool soundTrig = true;
    #endregion
    #region Lifecycle
    private void Awake()
    {
        sfx_ = GetComponent<SFX>();
        animator = GetComponent<Animator>();
        animatorOpenDoor = Animator.StringToHash(animatorOpenDoorName);
        animatorStartDoor = Animator.StringToHash(animatorStartDoorName);
    }
    #endregion
    #region Public Methods
    public void SetTrueStateOfTheDoor()
    {
        Debug.Log("sono entrato");
        animator.SetBool(animatorOpenDoorName, true);
        animator.SetBool(animatorStartDoorName, true);
        if (soundTrig == true)
        {
            sfx_.PlaySFX();
            soundTrig = false;
        }
    }
    public void SetFalseStateOfTheDoor()
    { 

        animator.SetBool(animatorOpenDoorName, false);
        if (soundTrig == false)
        {
            sfx_.PlaySFX();
            soundTrig = true;
        }
    }
    #endregion
    #region Private Methods
    #endregion
}
