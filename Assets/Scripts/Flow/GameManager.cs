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
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMenu()
    {
        sceneHandler.LoadScene("Menu");
    }
    #endregion

    #region Private Variables
    private void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    #endregion
}
