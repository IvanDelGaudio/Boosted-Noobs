using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationButton : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    private string animatorActiveButton = "Active";
    private int animatorBoolButton = 0;
    private bool controlAnimation=false;
    private Animator animator;
    #endregion
    #region Private Variables

    #endregion
    #region Lifecycle
    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorBoolButton = Animator.StringToHash(animatorActiveButton);
    }
    #endregion
    #region Public Methods
    public void SetTrueAnimationbutton()
    {
        Debug.Log("sono entrato");
        controlAnimation = true;
        animator.SetBool(animatorActiveButton, controlAnimation);

    }
    #endregion
    #region Private Methods
    #endregion
}
