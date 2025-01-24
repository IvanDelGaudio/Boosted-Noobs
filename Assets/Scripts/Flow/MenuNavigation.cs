using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MenuNavigation : MonoBehaviour
{
    #region Private Variables
    [Header("Data")]
    [SerializeField]
    private string sceneAddress;

    [Header("Panels")]
    [SerializeField]
    private GameObject[] panels;

    [Header("Buttons")]
    [SerializeField]
    private Button[] buttons;

    [Header("Play Panel Buttons")]
    [SerializeField]
    private Button playGameButton;
    [SerializeField]
    private Button[] playPanelButtons;

    [Header("Sprite")]
    [SerializeField]
    private Sprite empty;
    [SerializeField]
    private Sprite full;

    [Header("Colors")]
    [SerializeField]
    private Color selectedTextColor;
    [SerializeField]
    private Color unselectedTextColor;

    private SceneHandler sceneHandler;
    private bool isPlayPanelActive = false;
    #endregion

    #region Life Cycle
    private void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();
    }

    private void Update()
    {
        SelectedButton();
    }
    #endregion

    #region Public Methods
    public void Play()
    {
        sceneHandler.LoadScene(sceneAddress);
    }

    public void Quit()
    {
        sceneHandler.QuitGame();
    }
    #endregion

    #region Private Methods
    private void SelectedButton()
    {
        GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (isPlayPanelActive)
        {
            playGameButton.image.sprite = full;
            bool isInPlayPanel = false;
            foreach (Button playButton in playPanelButtons)
            {
                if (currentSelectedGameObject == playButton.gameObject)
                {
                    isInPlayPanel = true;
                    break;
                }
            }

            if (!isInPlayPanel)
            {
                isPlayPanelActive = false;
            }

            for (int i = 0; i < playPanelButtons.Length; i++)
            {
                if (currentSelectedGameObject == playPanelButtons[i].gameObject)
                {
                    ChangeButtonTextColor(playPanelButtons[i], selectedTextColor);
                }
                else
                {
                    ChangeButtonTextColor(playPanelButtons[i], unselectedTextColor);
                }
            }
        }

        if (!isPlayPanelActive)
        {
            playGameButton.image.sprite = empty;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (currentSelectedGameObject == buttons[i].gameObject)
                {
                    ActivatePanel(i);
                    ChangeButtonTextColor(buttons[i], selectedTextColor);

                    if (buttons[i] == playGameButton)
                        isPlayPanelActive = true;
                }
                else
                {
                    DeactivatePanel(i);
                    ChangeButtonTextColor(buttons[i], unselectedTextColor);
                }
            }
        }
    }


    private void ActivatePanel(int index)
    {
        if (index < panels.Length)
        {
            panels[index].SetActive(true);
        }
    }

    private void DeactivatePanel(int index)
    {
        if (index < panels.Length)
        {
            panels[index].SetActive(false);
        }
    }

    private void ChangeButtonTextColor(Button button, Color color)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            color.a = 1; // Ensure alpha is set to 1
            buttonText.color = color;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found in the button's children.");
        }
    }


    #endregion
}
