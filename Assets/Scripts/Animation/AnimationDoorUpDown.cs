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
    [Header ("Insert the initial state of the door")]
    private bool animatorStart=false;
    #endregion
    #region Private Variables
    private SFX sfx_;
    private Animator animator;
    #endregion
    #region Lifecycle
    private void Awake()
    {
        sfx_ = GetComponent<SFX>();
        animator = GetComponent<Animator>();
        animatorOpenDoor = Animator.StringToHash(animatorOpenDoorName);
    }
    #endregion
    #region Public Methods
    public void SetTrueStateOfTheDoor()
    { 
        animator.SetBool(animatorOpenDoorName, true);
        sfx_.PlaySFX();
    }
    public void SetFalseStateOfTheDoor()
    { 
        animator.SetBool(animatorOpenDoorName, false);
        sfx_.PlaySFX();
    }
    #endregion
    #region Private Methods
    #endregion
}
