using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    #region Private Variables
    [Header("Data")]
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gamOverPanel;
    [SerializeField]
    private GameObject subPanel;
    [SerializeField]
    private GameObject checkPointPanel;
    [SerializeField]
    private GameObject creditsPanel;

    private bool isPaused = false;
    private SceneHandler sceneHandler;
    #endregion

    #region Cycle Life
    private void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();

        pausePanel.SetActive(false);
        gamOverPanel.SetActive(false);
        subPanel.SetActive(false);
        checkPointPanel.SetActive(false);

        LockCursor();
    }

    private void Update()
    {
        PauseKeyCheck();
        CreditsKeyCheck();
    }
    #endregion

    #region Public Variables
    public void Resume()
    {
        DeactivatePanel(pausePanel);

        Time.timeScale = 1.0f;
        isPaused = false;

        LockCursor();
    }


    public void GoToMenu()
    {
        Resume();
        sceneHandler.LoadScene("Menu");
    }

    public void GameOver()
    {
        Pause(gamOverPanel);
    }

    public void Respawn()
    {
        Resume();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }


    public void ActivatePanelForSeconds(GameObject panel, float duration)
    {
        StartCoroutine(ActivateThenDeactivate(panel, duration));
    }
    #endregion

    #region Private Variables
    private void Pause(GameObject panel)
    {
        ActivatePanel(panel);
        Time.timeScale = 0.0f;
        isPaused = true;

        UnlockCursor();
    }

    private IEnumerator ActivateThenDeactivate(GameObject panel, float duration)
    {
        ActivatePanel(panel);
        yield return new WaitForSeconds(duration);
        DeactivatePanel(panel);
    }

    private void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    private void PauseKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause(pausePanel);
            }
        }
    }

    private void CreditsKeyCheck()
    {
        if (creditsPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            GoToMenu();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion
}
