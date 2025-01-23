using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class KeyItem : MonoBehaviour
    {
        [SerializeField]
        Inventory.Item item;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

