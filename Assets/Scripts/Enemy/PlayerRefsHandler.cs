using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRefsHandler : MonoBehaviour
{
    #region Public variables
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
    public void ClearPlayerRefs()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    #region Private methods
    #endregion

    
}
