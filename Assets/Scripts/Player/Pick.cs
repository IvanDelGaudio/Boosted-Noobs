using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class Pick : MonoBehaviour
    {
        public Item item = new Item("Item Name");

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}
