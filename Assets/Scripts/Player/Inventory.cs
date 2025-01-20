using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        public List<Item> items = new List<Item>();

        void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;
        }

        public void AddItem(Item itemToAdd)
        {
            bool itemExists = false;

            foreach (Item item in items)
            {
                if (item.name == itemToAdd.name)
                {
                    itemExists = true;
                    break;
                }
            }
            if (!itemExists)
            {
                items.Add(itemToAdd);
            }
            Debug.Log(" " + itemToAdd.name + " added to inventory.");
        }

        public void RemoveItem(Item itemToRemove)
        {
            foreach (var item in items)
            {
                if (item.name == itemToRemove.name)
                {
                    
                 items.Remove(itemToRemove);
                }
            }
            Debug.Log(" " + itemToRemove.name + "removed from inventory.");
        }
    }

}

