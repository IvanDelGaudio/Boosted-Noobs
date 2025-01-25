using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    #region Public variables
    public delegate void CheckpointActivated(Vector3 checkpointPosition);
    public static event CheckpointActivated OnSave;
    public GameManager gameManager;
    public GameObject checkpoint;
    public string checkpointID; 
    #endregion

    #region Private variables
    private Vector3 checkpointPosition;
    #endregion

    #region Lifecycle
    private void Start()
    {
        
        if (IsCheckpointActivated(checkpointID))
        {
            Destroy(this.gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SavePosition(transform.position);
            MarkCheckpointAsActivated(checkpointID);
            OnSave?.Invoke(transform.position);
            Debug.Log("Checkpoint saved at: " + transform.position);
            Destroy(this.gameObject);
            gameManager.ActivatePanelForSeconds(checkpoint,5);
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
    }

    public static void MarkCheckpointAsActivated(string id)
    {
        string savedCheckpoints = PlayerPrefs.GetString("ActivatedCheckpoints", "");
        List<string> checkpointList = new List<string>(savedCheckpoints.Split(','));

        if (!checkpointList.Contains(id))
        {
            checkpointList.Add(id);
            PlayerPrefs.SetString("ActivatedCheckpoints", string.Join(",", checkpointList));
            PlayerPrefs.Save();
        }
    }

    public static bool IsCheckpointActivated(string id)
    {
        string savedCheckpoints = PlayerPrefs.GetString("ActivatedCheckpoints", "");
        List<string> checkpointList = new List<string>(savedCheckpoints.Split(','));
        return checkpointList.Contains(id);
    }
    #endregion
}
