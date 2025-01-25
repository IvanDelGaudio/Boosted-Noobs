using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    public List<FuseItem> fuse = new List<FuseItem>();

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    

    public void AddItem(Item itemToAdd)
    {
        //if (items.Contains(itemToAdd))

        items.Add(itemToAdd);

        Debug.Log(itemToAdd + " added to inventory.");
    }
    public void AddFuse(FuseItem fuseToAdd)
    {


        fuse.Add(fuseToAdd);



        Debug.Log(fuseToAdd + " added to inventory.");
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
        Debug.Log(itemToRemove + " removed to inventory.");

    }

    public enum Item
    {
        None,
        KeyCardRed,
        KeyCardBlue,
        KeyCardGreen
    }

    public enum FuseItem
    {
        None,
        FuseRed,
        FuseBlue,
        FuseGreen
    }

}


