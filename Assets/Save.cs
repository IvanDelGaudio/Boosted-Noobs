using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    #region Public variables
    public delegate void CheckpointActivated(Vector3 checkpointPosition);
    public static event CheckpointActivated OnSave;
    #endregion

    #region Private variables
    private Vector3 checkpointPosition;
    #endregion
    private void Start()
    {
        Debug.Log(this.gameObject.tag);
    }
    #region Lifecycle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SavePosition(transform.position);
            OnSave?.Invoke(transform.position);
            Debug.Log("Checkpoint saved at: " + transform.position);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No collision");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SavePosition(transform.position);
            OnSave?.Invoke(transform.position);
            Debug.Log("Checkpoint saved at: " + transform.position);
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Public methods
    public void SavePosition(Vector3 position)
    {
        PlayerPrefs.SetFloat("CheckpointPositionX", position.x);
        PlayerPrefs.SetFloat("CheckpointPositionY", position.y);
        PlayerPrefs.SetFloat("CheckpointPositionZ", position.z);
        PlayerPrefs.Save();
        Debug.Log($"CheckpointPositionX, {position.x}");
        Debug.Log($"CheckpointPositionY, {position.y}");
        Debug.Log($"CheckpointPositionZ, {position.z}");
    }
    #endregion
}
