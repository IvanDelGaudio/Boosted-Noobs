using UnityEngine;
[RequireComponent(typeof(SFX))]
public class Collectables : MonoBehaviour
{
    #region Public variables
    public delegate void CollectibleCollected(Transform collectible);
    public static event CollectibleCollected OnCollected;
    #endregion
    private SFX sfx;
    private void Start()
    {
        sfx=GetComponent<SFX>();
    }
    #region Public methods
    public bool CheckDistance(Transform player)
    {
        if (Vector3.Distance(player.position, transform.position) < 1.5)
        {
            OnCollected?.Invoke(transform);
            sfx.PlaySFX(0);
            Destroy(gameObject); // Remove the collectible
            return true;
        }
        return false;

    }
    #endregion
}
