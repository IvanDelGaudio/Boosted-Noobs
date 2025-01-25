using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    #region Public variables

    #endregion

    #region Private variables
    [SerializeField] private SceneHandler sceneHandler;
    [SerializeField] private string secondoLevelName;

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
    #endregion

    #region Private methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneHandler.LoadScene(secondoLevelName);

        }
    }
    #endregion


}
