using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHall : MonoBehaviour
{
    #region Public variables
    public delegate void HallTeleportationTriggered(Transform location);
    public static event HallTeleportationTriggered OnHallTeleportation;
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
    public void HallTeleportation(Transform hallTeleportPosition)
    {
        OnHallTeleportation?.Invoke(hallTeleportPosition);
        Debug.Log(this.transform.position);
        Debug.Log($"Teleport gestito da {gameObject.name} con position {hallTeleportPosition.position}");
        Destroy(this.gameObject);
    }
    #endregion

    #region Private methods
    #endregion


}
