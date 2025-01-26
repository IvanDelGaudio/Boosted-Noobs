using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTeleportHall : MonoBehaviour
{
    #region Public variables
    public TeleportHall associatedTeleport;

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

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            associatedTeleport?.HallTeleportation(associatedTeleport.transform);
            Destroy(gameObject); // Remove the collectible
        }
    }    
    #endregion

}
