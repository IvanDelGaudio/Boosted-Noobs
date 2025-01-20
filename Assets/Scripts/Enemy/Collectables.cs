using UnityEngine;

public class Collectables : MonoBehaviour
{
    public delegate void CollectibleCollected(Transform collectible);
    public static event CollectibleCollected OnCollected;
    
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
    
}
