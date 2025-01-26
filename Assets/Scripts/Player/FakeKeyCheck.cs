using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeKeyCheck : MonoBehaviour
{
    [SerializeField]
    bool playerInRange;
    [SerializeField]
    bool isExit = false;
    [SerializeField]
    Inventory.Item requiredItem;
    [SerializeField]
    public Text text;
    public bool requiredKey = false;
    public LightManager light;

    private void Start()
    {
        text.text = "";
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
        if (requiredKey == true && playerInRange)
        {
            light.ChangeColorButton3();
        }
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            CheckDoorKey();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = "";
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
        if (requiredKey == true)
        {
            light.ChangeColorButton3();
            isExit = true;
            Debug.Log("Door is open");
        }
    }
}
