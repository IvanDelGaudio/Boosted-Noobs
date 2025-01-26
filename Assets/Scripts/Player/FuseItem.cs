using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseItem : MonoBehaviour
{
    public IconsManager FuseMenu;
    [SerializeField]
    Inventory.FuseItem fuse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuseMenu.ToggleFuseIcon();
            Inventory.instance.AddFuse(fuse);
            Destroy(gameObject);
        }
    }
}
