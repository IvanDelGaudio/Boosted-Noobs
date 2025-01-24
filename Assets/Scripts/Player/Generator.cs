using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    bool playerInRange;
    [SerializeField]
    Inventory.FuseItem requiredFuseRed;
    [SerializeField]
    Inventory.FuseItem requiredFuseBlue;
    [SerializeField]
    Inventory.FuseItem requiredFuseGreen;
    [SerializeField]
    public GameObject CanvasOpenDoor;
    public bool FuseRed;
    public bool FuseBlue;
    public bool FuseGreen;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckFuses();
    }

    public bool RequiredRedFuse(Inventory.FuseItem FuseRequired)
    {
        if (Inventory.instance.fuse.Contains(FuseRequired))
        {
            FuseRed = true;
            Debug.Log("Use Fuse Red");
            return true;
        }
        else
        {
            Debug.Log("Fuse Red is don't the inventory");
            return false;
        }
    }
    public bool RequiredBlueFuse(Inventory.FuseItem FuseRequired)
    {
        if (Inventory.instance.fuse.Contains(FuseRequired))
        {
           
            Debug.Log("Use Fuse Blue");
            return true;
        }
        else
        {
            Debug.Log("Fuse Blue is don't the inventory");
            return false;
        }
    }


    public bool RequiredGreenFuse(Inventory.FuseItem FuseRequired)
    {
        if (Inventory.instance.fuse.Contains(FuseRequired))
        {
            FuseGreen = true;
            Debug.Log("Use Fuse Green");
            return true;
        }
        else
        {
            Debug.Log("Fuse Green is don't the inventory");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            CanvasOpenDoor.SetActive(true);
            //FuseBlue = RequiredBlueFuse(requiredFuseBlue);
            Debug.Log("Player has enter");
            playerInRange = true;

        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            FuseBlue = RequiredBlueFuse(requiredFuseBlue);
            CheckFuses();
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
    private void CheckFuses()
    {
        //Fuses = RequiredFuses(requiredFuse);
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            RequiredRedFuse(requiredFuseRed);
            RequiredBlueFuse(requiredFuseBlue);
            RequiredGreenFuse(requiredFuseGreen);
        }
         
        Debug.Log("Palle");
    }



}
