using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Public variables
    public GameObject levelButtonPrefab;
    public Transform levelButtonContainer;
    public string[] buttonsNames;
    public string logicSceneName;

    #endregion
    #region Private variables
    private SceneHandler sceneHandler;
    #endregion
    #region Lifecycle
    void Start()
    {
        sceneHandler = new SceneHandler();
        CreateButtons(buttonsNames);
    }
    #endregion
    #region Public methods
        
    public void CreateButtons(string[] buttonsNames)
    {
        foreach (string name in buttonsNames)
        {
            GameObject newButton = Instantiate(levelButtonPrefab, levelButtonContainer);
            newButton.GetComponentInChildren<Text>().text = name;
            newButton.GetComponent<Button>().onClick.AddListener(() => sceneHandler.LoadLevel(name,logicSceneName));
        }
    }
        

    #endregion
    #region Private methods
    #endregion


}

