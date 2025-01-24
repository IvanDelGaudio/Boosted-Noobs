using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    bool playerInRange;
    public bool generatorOpen { get; private set; }
    [SerializeField]
    public bool FuseRed;
    [SerializeField]
    public bool FuseBlue;
    [SerializeField]
    public bool FuseGreen;
    [SerializeField]
    Inventory.FuseItem requiredFuseRed;
    [SerializeField]
    Inventory.FuseItem requiredFuseBlue;
    [SerializeField]
    Inventory.FuseItem requiredFuseGreen;
    [SerializeField]
    public GameObject CanvasFuse;
    [SerializeField]
    public Renderer Warning;
    private bool ChFuseRed;
    private bool ChFuseBlue;
    private bool ChFuseGreen;

    private void Start()
    {

    }

    private void Update()
    {
        CheckFuse();
        CheckAll();
    }

    public bool RequiredRedFuse(Inventory.FuseItem itemRequired)
    {
        if (Inventory.instance.fuse.Contains(itemRequired))
        {
            Debug.Log("Red Fuse Yes");
            return true;
        }
        else
        {
            Debug.Log("Nope");
            return false;
        }
    }
    public bool RequiredBlueFuse(Inventory.FuseItem itemRequired)
    {
        if (Inventory.instance.fuse.Contains(itemRequired))
        {
            Debug.Log("Blue Fuse Yes");
            return true;
        }
        else
        {
            Debug.Log("Nope");
            return false;
        }
    }
    public bool RequiredGreenFuse(Inventory.FuseItem itemRequired)
    {
        if (Inventory.instance.fuse.Contains(itemRequired))
        {
            Debug.Log("Green Fuse Yes");
            return true;
        }
        else
        {
            Debug.Log("Nope");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvasFuse.SetActive(true);
            RequiredRedFuse(requiredFuseRed);
            RequiredBlueFuse(requiredFuseBlue);
            RequiredGreenFuse(requiredFuseGreen);
            Debug.Log("Player has enter");
            playerInRange = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            CheckFuseRed();
            CheckFuseBlue();
            CheckFuseGreen();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvasFuse.SetActive(false);
            Debug.Log("Player has exit");
            playerInRange = false;
        }
    }

    private void CheckFuse()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
           CheckFuseRed();
           CheckFuseBlue();
           CheckFuseGreen();      
        }
    }
    private void CheckFuseRed()
    {
        ChFuseRed = RequiredRedFuse(requiredFuseRed);
        if (FuseRed == false && ChFuseRed == true)
        {
            FuseRed = true;
            Debug.Log("Red is True");
        }
    }
    private void CheckFuseBlue()
    {
        ChFuseBlue = RequiredBlueFuse(requiredFuseBlue);
        if (FuseBlue == false && ChFuseBlue == true)
        {
            FuseBlue = true;
            Debug.Log("blue is True");
        }
    }
    private void CheckFuseGreen()
    {
        ChFuseGreen = RequiredGreenFuse(requiredFuseGreen);
        if (FuseGreen == false && ChFuseGreen == true)
        {
            FuseGreen = true;
            Debug.Log("green is True");
        }
    }

    private void CheckAll()
    {
        if (FuseRed == true && FuseBlue == true && FuseGreen == true)
        {
            generatorOpen = true;
            Warning.material.color = Color.red;
            Debug.Log("Luca ci uccide");
        }
    }
}
