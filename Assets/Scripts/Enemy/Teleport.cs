using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    #region Public variables
    public delegate void TeleportationTriggered(Transform location);
    public static event TeleportationTriggered OnTeleportation;
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
    public void Teleportation(Transform teleportPosition)
    {
        OnTeleportation?.Invoke(teleportPosition);
        Debug.Log(this.transform.position);
        Debug.Log($"Teleport gestito da {gameObject.name} con position {teleportPosition.position}");
        Destroy(this.gameObject);
    }
    #endregion

    #region Private methods
    #endregion


}
