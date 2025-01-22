using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
[RequireComponent (typeof(Animator))]
public class AnimetionDoorUpDown : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    private string animatorOpenDoorName = "Open";
    private int animetorOpenDoor = 0;
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
        animetorOpenDoor = Animator.StringToHash(animatorOpenDoorName);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sfx_.PlaySFX();
            animator.SetBool(animatorOpenDoorName, true);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            sfx_.PlaySFX();
            animator.SetBool(animatorOpenDoorName, false);
        }
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    #endregion
}
