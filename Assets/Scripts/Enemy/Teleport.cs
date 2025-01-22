using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    #region Public variables
    public delegate void TeleportationTriggered(Transform location);
    public static event TeleportationTriggered OnTeleport;
    #endregion

    #region Private variables
    #endregion

    #region Public properties
    #endregion

    #region Private properties
    #endregion

    #region Lifecycle
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Public methods
    public void OnEnable()
    {
        OnTeleport?.Invoke(this.transform);
        //Destroy(this.gameObject); // Remove the collectible
    }
    #endregion

    #region Private methods
    #endregion


}
