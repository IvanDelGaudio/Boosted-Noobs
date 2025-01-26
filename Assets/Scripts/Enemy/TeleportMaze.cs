using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMaze : MonoBehaviour
{
    #region Public variables
    public delegate void MazeTeleportationTriggered(Transform location);
    public static event MazeTeleportationTriggered OnMazeTeleportation;
    #endregion

    #region Private variables
    #endregion

    #region Public properties
    #endregion

    #region Private properties
    #endregion

    #region Lifecycle
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Public methods
    public void MazeTeleportation(Transform mazeTeleportPosition)
    {
        OnMazeTeleportation?.Invoke(mazeTeleportPosition);
        Debug.Log(this.transform.position);
        Debug.Log($"Teleport Maze gestito da {gameObject.name} con position {mazeTeleportPosition.position}");
        Destroy(this.gameObject);
    }
    #endregion

    #region Private methods
    #endregion


}
