using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

[RequireComponent(typeof(AnimationDoorUpDown))]
public class KeyCheck : MonoBehaviour
{

        [SerializeField]
        GameObject door;
        [SerializeField]
        bool playerInRange;
    [SerializeField]
    float timeForSetDoorClose = 2.0f;
    [SerializeField]
        public bool isdoorOpen;
    [SerializeField]
    public bool doorOpenCheckKey=false;
    [SerializeField]
    bool isExit = false;
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

    public void CloseTheDoor()
    {
        Debug.Log("Player has exit");
        playerInRange = false;
        anim.SetFalseStateOfTheDoor();
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
          if (other.gameObject.CompareTag("Player") )
          {
              CanvasOpenDoor.SetActive(false);
              Debug.Log("Player has exit");
              playerInRange = false;
          }
          
      }

    private void CheckKey()
    {
        if(doorOpenCheckKey == true)
        {
            CheckDoorKey();
        }
        else if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            CheckDoorKey();
            
        }
    }
    private void CheckDoorKey()
    {
        requiredKey = RequiredItems(requiredItem);
        if (isdoorOpen == false && requiredKey == true)
        {
            anim.SetTrueStateOfTheDoor();
            isdoorOpen = true;
            isExit = true;
            Debug.Log("Door is open");
        }
    }
}

