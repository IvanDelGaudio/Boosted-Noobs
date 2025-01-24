using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseItem : MonoBehaviour
{
    [SerializeField]
    Inventory.FuseItem fuse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddFuse(fuse);
            Destroy(gameObject);
        }
    }
}
