using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class AnimationDoorController : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Animator animator;

    private Vector3 originalPosition;
    private float animatedY;
    #endregion

    #region Cycle Life
    private void Start()
    {
        originalPosition = transform.position;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        AnimateYPosition();
    }
    #endregion

    #region Private Methods
    private void AnimateYPosition()
    {
        animatedY = animator.GetFloat("AnimatedY");

        transform.position = new Vector3(originalPosition.x, originalPosition.y + animatedY, originalPosition.z);
    }
    #endregion
}
