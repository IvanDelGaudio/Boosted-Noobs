using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Private Variables
    [Header("Data")]
    [SerializeField]
    private GameObject pausePanel;
    
    private bool isPaused = false;
    private SceneHandler sceneHandler;
    #endregion

    #region Cycle Life
    private void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();

        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    #endregion

    #region Public Variables
    public void Resume()
    {
        DeactivatePanel(pausePanel);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMenu()
    {
        sceneHandler.LoadScene("Menu");
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    #endregion

    #region Private Variables
    private void Pause()
    {
        ActivatePanel(pausePanel);
        Time.timeScale = 0f;
        isPaused = true;
    }
    #endregion
}
