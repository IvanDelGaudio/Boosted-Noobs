using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationDoorUpDown))]
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
    private AnimationDoorUpDown anim;
        private void Start()
        {
            CanvasOpenDoor.SetActive(false);
        anim = GetComponent<AnimationDoorUpDown>();
        }

        private void Update()
        {
            CheckKey();
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

    private void CheckKey()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            requiredKey = RequiredItems(requiredItem);
            if (isdoorOpen == false && requiredKey == true)
            {
                isdoorOpen = true;
                Debug.Log("Door is open");
            }
        }
    }
}

