using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    #region Public Variables
    public KeyCheck door;
    #endregion
    #region Private Variables
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    private void OnTriggerExit(Collider other)
    {
        door.isdoorOpen = false;
        door.CloseTheDoor();
        Debug.Log("sono entrato stronzo di merda");
        door.CanvasOpenDoor.SetActive(false);
    }
    #endregion
}
