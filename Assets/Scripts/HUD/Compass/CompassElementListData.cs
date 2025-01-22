using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCompassElementListData", menuName = "Compass/Compass Element List Data")]
public class CompassElementListData : ScriptableObject
{
    public List<CompassElementData> elementDataList = new List<CompassElementData>();  // Use the struct in the ScriptableObject
}

[System.Serializable]
public struct CompassElementData
{
    public Transform targetTransform;
    public Sprite elementSprite;
}