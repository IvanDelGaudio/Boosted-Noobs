using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;
using UnityEngine;

public class CheckGeneratorSave : MonoBehaviour
{
    #region Public variables
    #endregion

    #region Private variables
    private Collider collider;
    private bool generatorOpen;
    [SerializeField] private Generator generator;
    #endregion

    #region Public properties
    #endregion

    #region Private properties
    #endregion

    #region Lifecycle
    void Awake()
    {
        collider = gameObject.GetComponent<BoxCollider>();
    }
    void Update()
    {
        generatorOpen = generator.generatorOpen;
        CheckGeneratorCheckpoint();
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    public void CheckGeneratorCheckpoint() 
    {
        if (generatorOpen == true)
        {
            collider.enabled = true;   
        }
        else if(generatorOpen == false)
        {
            collider.enabled = false;
        }
    }
    #endregion

    
}
