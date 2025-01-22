using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class SummaryScreenManager : MonoBehaviour
{
    #region Private variables
    private Animator animator = null;
    [Header("Animator")]
    [SerializeField]
    private string animatorVisibleBoolParamName = "Visible";
    private int? _animatorVisibleBool = null;
    [Header("Layout")]
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button mainMenuButton;

    private SceneHandler sceneHandler;
    #endregion
    #region Public properties
    public bool visible
    {
        get => animator.GetBool(animatorVisibleBool);
        set => animator.SetBool(animatorVisibleBool, value);
    }
    #endregion
    #region Private properties
    private int animatorVisibleBool
    {
        get
        {
            if (
                _animatorVisibleBool == null ||
                !_animatorVisibleBool.HasValue
            )
                _animatorVisibleBool = Animator.StringToHash(animatorVisibleBoolParamName);

            return _animatorVisibleBool.Value;
        }
    }
    #endregion
    #region Lifecycle
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        quitButton.onClick.AddListener(HandleQuitRequest);
        mainMenuButton.onClick.AddListener(HandleBackToMainMenuRequest);
    }
    #endregion

    #region Private methods
    private void HandleQuitRequest()
    {
        Application.Quit();
    }
    private void HandleBackToMainMenuRequest()
    {
        sceneHandler.LoadScene("Menu");
    }
    #endregion
}