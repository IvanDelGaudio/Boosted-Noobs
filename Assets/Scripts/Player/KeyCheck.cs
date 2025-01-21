using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    //[RequireComponent(typeof(Animator))]
    public class KeyCheck : MonoBehaviour
    {

        [SerializeField]
        GameObject door;
        [SerializeField]
        bool playerInRange;
        [SerializeField]
        bool isdoorOpen;

        [SerializeField]
        Inventory.Item requiredItem;
        private GameObject Wall;

        private void Start()
        {
            Wall = GameObject.FindWithTag("Wall");
        }

        private void Update()
        {

            if (Input.GetKeyUp(KeyCode.E) && playerInRange)
            {
                if (isdoorOpen == false)
                {
                    isdoorOpen = true;
                    Destroy(Wall);
                    Debug.Log("Door is open");
                }
            }
        }


        public bool RequiredItems(Inventory.Item itemRequired)
        {
            if (Inventory.instance.items.Contains(itemRequired))
            {
                Destroy(Wall);
                Debug.Log("The Red Door is open");
                return true;
            }
            else
            {
                Debug.Log("The Red Door is not open");
                return false;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                RequiredItems(requiredItem);
                Debug.Log("Player has enter");
                playerInRange = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player has exit");
                playerInRange = false;
            }
        }


    }
}
