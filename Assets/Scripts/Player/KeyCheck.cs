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
        [SerializeField]
        GameObject CanvasOpenDoor;
        private bool requiredKey;
        private void Start()
        {
            CanvasOpenDoor.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E) && playerInRange)
            {
                requiredKey = RequiredItems(requiredItem);
                if (isdoorOpen == false && requiredKey == true)
                {
                    isdoorOpen = true;
                    Destroy(gameObject);
                    Debug.Log("Door is open");
                }
            }
        }


        public bool RequiredItems(Inventory.Item itemRequired)
        {
            if (Inventory.instance.items.Contains(itemRequired))
            {
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
                CanvasOpenDoor.SetActive(true);
                RequiredItems(requiredItem);
                Debug.Log("Player has enter");
                playerInRange = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CanvasOpenDoor.SetActive(false);
                Debug.Log("Player has exit");
                playerInRange = false;
            }
        }


    }
}
