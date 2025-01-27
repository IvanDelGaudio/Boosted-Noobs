using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    #region Public variables
    public GameManager gameManager;
    public GameObject checkpoint;
    #endregion

    #region Private variables
    [SerializeField] private SceneHandler sceneHandler;
    [SerializeField] private string secondoLevelName;
    [SerializeField] private SceneData sceneData;

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
            sceneData.sceneName = "Level 02";
            ChangeSceneName(secondoLevelName);
            Debug.Log("Nome della scena impostato a: " + sceneData.sceneName);
            gameManager.ActivatePanelForSeconds(checkpoint, 5);
        }
    }

    private void ChangeSceneName(string newSceneName)
    {
        if (sceneData != null)
        {
            sceneData.sceneName = newSceneName;

        #if UNITY_EDITOR
                    EditorUtility.SetDirty(sceneData);
                    AssetDatabase.SaveAssets();
        #endif
        }
        else
        {
            Debug.LogError("SceneData non è stato assegnato.");
        }
    }
    #endregion


}