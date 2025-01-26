using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

[RequireComponent(typeof(AnimationDoorController))]
public class KeyCheck : MonoBehaviour
{
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
    public Text text;
    public bool requiredKey=false;
    private AnimationDoorController anim;
    
    private void Start()
    {
    text.text="";
    anim = GetComponent<AnimationDoorController>();
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
            doorOpenCheckKey = true;
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
        isdoorOpen = false;
        anim.SetFalseDoor();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!requiredKey)
            {
                text.text = "Press E";
            }
            RequiredItems(requiredItem);
            Debug.Log("Player has enter");
            playerInRange = true;
        }
        if (requiredKey == true && anim.controlOpenDoor == false && playerInRange)
        {
            anim.SetTrueStateOfTheDoor();
        }
        if (Input.GetKeyUp(KeyCode.E) && doorOpenCheckKey == true && anim.controlOpenDoor == false)
        {
                CheckDoorKey();
        }
        
    }
      private void OnTriggerExit(Collider other)
      {
        if (other.gameObject.CompareTag("Player") )
          {
              text.text="";
              Debug.Log("Player has exit");
              playerInRange = false;
          }
          
      }

    private void CheckKey()
    {

        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            CheckDoorKey();
        }
    }
    private void CheckDoorKey()
    {
        requiredKey = RequiredItems(requiredItem);
        if (isdoorOpen == false && requiredKey == true )
        {
            anim.SetTrueStateOfTheDoor();
            isdoorOpen = true;
            isExit = true;
            Debug.Log("Door is open");
        }
    }
}

