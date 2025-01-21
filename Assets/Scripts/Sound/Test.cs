using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SFX))]
public class Test : MonoBehaviour
{
    #region Public Variables
    private SFX sfx_;
    #endregion
    #region Private Variables
    #endregion
    #region Lifecycle
    private void Awake()
    {
        sfx_ = GetComponent<SFX>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            sfx_.PlaySFX();
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    #endregion
}
