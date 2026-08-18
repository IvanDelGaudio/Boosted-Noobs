using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SFX))]
public class CloseDoorLocked : MonoBehaviour
{
    #region Public Variables
    public KeyCheck door;
    public Light light;
    public Material material;
    public Renderer button;
    #endregion
    #region Private Variables
    private bool finishedSound;
    private SFX sfx;
    #endregion
    #region Lifecycle
    private void Start()
    {
        sfx = GetComponent<SFX>();
    }
    private void Update()
    {
        checkEndTheSong();
    }
    #endregion
    #region Public Methods

    #endregion
    #region Private Methods
    private void OnTriggerExit(Collider other)
    {
        if (finishedSound == false)
        {
            door.isdoorOpen = false;
            sfx.PlaySFX(0);
            finishedSound = true;
        }
    }
    private void checkEndTheSong()
    {
        if (sfx.audioSource == null && finishedSound == true)
        {
            door.CloseTheDoor();
            Debug.Log("sei un coglione");
            light.color = Color.red;
            button.material = material;
            door.requiredKey = false;
            Destroy(gameObject);
        }
    }
    #endregion
}
