using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTeleport : MonoBehaviour
{
    #region Public variables
    public delegate void BubbleTeleportationTriggered(Transform location);
    public static event BubbleTeleportationTriggered OnTeleport;
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
    
    #endregion

    #region Private methods
    
    public bool CheckDistance(Transform player)
    {
        if (Vector3.Distance(player.position, transform.position) < 1.5)
        {
            OnTeleport?.Invoke(transform);
            Destroy(gameObject); // Remove the collectible
            return true;
        }
        return false;

    }
    #endregion

}
