using System.Collections.Generic;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    public CompassDisplay compassDisplay;  // Reference to the CompassDisplay component
    public CompassElementListData compassElementListData;  // Reference to the ScriptableObject list

    void Start()
    {
        if (compassElementListData != null)
        {
            foreach (CompassElementData elementData in compassElementListData.elementDataList)
            {
                if (elementData.targetTransform != null)
                {
                    compassDisplay.RegisterCompassElement(elementData);
                }
            }
        }
        else
        {
            Debug.LogWarning("CompassElementListData is not assigned!");
        }
    }

    // Method to add all elements from the ScriptableObject list to the compass
    public void AddElementsFromList()
    {
        if (compassElementListData != null)
        {
            foreach (CompassElementData elementData in compassElementListData.elementDataList)
            {
                if (elementData.targetTransform != null)
                {
                    compassDisplay.RegisterCompassElement(elementData);
                }
            }
        }
    }

    // Method to remove all elements from the ScriptableObject list from the compass
    public void RemoveElementsFromList()
    {
        if (compassElementListData != null)
        {
            foreach (CompassElementData elementData in compassElementListData.elementDataList)
            {
                if (elementData.targetTransform != null)
                {
                    compassDisplay.UnregisterTransform(elementData.targetTransform);
                }
            }
        }
    }

    // Method to clear all elements dynamically
    public void ClearAllElements()
    {
        if (compassDisplay != null)
        {
            List<Transform> targetsToClear = new List<Transform>();

            foreach (CompassElement element in compassDisplay.GetComponentsInChildren<CompassElement>())
            {
                targetsToClear.Add(element.referencedTransform);
            }

            foreach (Transform target in targetsToClear)
            {
                compassDisplay.UnregisterTransform(target);
            }
        }
    }
}
