using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Public variables
    [SerializeField] private List<Save> saveCheckpoints;
    #endregion

    #region Lifecycle
    void Start()
    {
        InitializeCheckpoints();
    }
    private void Update()
    {

    }
    #endregion

    #region Private methods
    private void InitializeCheckpoints()
    {
        foreach (var checkpoint in saveCheckpoints)
        {
            if (Save.IsCheckpointActivated(checkpoint.checkpointID))
            {
                Destroy(checkpoint.gameObject);
            }
        }
    }
    #endregion
}
    

