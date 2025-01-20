using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MenuNavigation : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    [Header("Data")]
    private string sceneAddress;

    private SceneHandler sceneHandler;
    #endregion

    #region Life Cycle
    private void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();
    }
    #endregion

    #region Public Methods
    public void Play()
    {
        sceneHandler.LoadScene(sceneAddress);
    }
    #endregion

}
