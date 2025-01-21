using UnityEngine;

public class Collectables : MonoBehaviour
{
    #region Public variables
    public delegate void CollectibleCollected(Transform collectible);
    public static event CollectibleCollected OnCollected;
    #endregion

    #region Public methods
    public bool CheckDistance(Transform player)
    {
        if (Vector3.Distance(player.position, transform.position) < 1.5)
        {
            OnCollected?.Invoke(transform);
            Destroy(gameObject); // Remove the collectible
            return true;
        }
        return false;

    }
    #endregion
}
