using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
public class TriggeredVoiceLine : MonoBehaviour
{
    #region Public Variables
    #endregion
    #region Private Variables
    private SFX sfx;
    private bool endSound=false;
    #endregion
    #region Lifecycle
    private void Start()
    {
        sfx = GetComponent<SFX>();
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (endSound == false)
            {
                sfx.PlaySFX(0);
                endSound = true;
            }
        }
    }
    #endregion
}
