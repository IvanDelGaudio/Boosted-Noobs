using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class IconsManager : MonoBehaviour
{
    #region Private Variables
    [Header("Data")]
    [SerializeField]
    private GameObject keyIcon;
    [SerializeField]
    private GameObject fuseIcon;

    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI valueText;
    
    private int value = 0;
    #endregion

    #region Cycle Life

    void Start()
    {
        UpdateValueText();
        keyIcon.SetActive(false);
        fuseIcon.SetActive(false);
    }

    #endregion

    #region Public Methods
    public void ToggleKeyIcon()
    {
        keyIcon.SetActive(!keyIcon.activeSelf);
    }

    public void ToggleFuseIcon()
    {
        if (value < 3)
        {
            fuseIcon.SetActive(true);
            value++;
            UpdateValueText();
        }
    }

    public void UntoggleFuseIcon()
    {
        fuseIcon.SetActive(false);
        value = 0;
    }
    #endregion

    #region Private Methods

    private void UpdateValueText()
    {
        valueText.text = value.ToString() + "/3";
    }
    #endregion
}
