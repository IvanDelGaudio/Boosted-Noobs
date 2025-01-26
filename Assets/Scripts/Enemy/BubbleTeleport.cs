using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
public class BubbleTeleport : MonoBehaviour
{
    #region Public variables
    public Teleport associatedTeleport;

    #endregion

    #region Private variables
    private SFX sfx;
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
        sfx = GetComponent<SFX>();
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
            associatedTeleport?.Teleportation(associatedTeleport.transform);
            sfx.PlaySFX(0);
            Destroy(gameObject); // Remove the collectible
            return true;
        }
        return false;   
    }
    #endregion

}
