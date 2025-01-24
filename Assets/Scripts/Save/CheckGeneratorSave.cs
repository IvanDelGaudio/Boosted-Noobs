using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGeneratorSave : Generator
{
    #region Public variables
    #endregion

    #region Private variables
    private Collider collider;
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
    void Start()
    {
        
    }

    void Update()
    {
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
