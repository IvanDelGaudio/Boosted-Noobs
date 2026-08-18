using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using S = System;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]
public class CompassElement : MonoBehaviour
{
    #region Public variables
    [S.NonSerialized]
    public Transform referencedTransform = null;
    public Image elementImage;
    #endregion
    #region Private variables
    private float _visibility = 0.0f;
    private CanvasGroup canvasGroup = null;
    [Header("Layout")]
    [SerializeField]
    private TextMeshProUGUI distanceLabel;
    [Header("Visibility")]
    [SerializeField]
    [Tooltip("The element will start to fade when the visibility hits this value and will completely fade at 0.0f")]
    private AnimationCurve alphaOverVisibility = new AnimationCurve(
        new Keyframe[]
        {
                new Keyframe(0.0f, 0.0f),
                new Keyframe(0.4f, 1.0f)
        }
    );
    [SerializeField]
    [Tooltip("The element will start to shrink when the visibility hits this value and will completely shrink to final shrink amount at 0.0f")]
    private AnimationCurve scaleOverVisibility = new AnimationCurve(
        new Keyframe[]
        {
                new Keyframe(0.0f, 0.0f),
                new Keyframe(0.8f, 1.0f)
        }
    );
    [Header("Display")]
    [SerializeField]
    [Range(1.0f, 999.0f)]
    private float maxRepresentableDistance = 500.0f;
    [SerializeField]
    [Tooltip("This text is shown instead of the distance when the distance is farther than max representable distance. This can be any string with length 0 to 3 (included) characters")]
    private string distanceOverflowText = "FAR";
    #endregion
    #region Public properties
    public float visibility
    {
        get => _visibility;
        set
        {
            _visibility = Mathf.Clamp01(value);
            canvasGroup.alpha = alphaOverVisibility.Evaluate(value);
            transform.localScale = Vector3.one * scaleOverVisibility.Evaluate(value);
        }
    }
    #endregion
    #region Lifecycle
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        distanceLabel.text = string.Empty;
    }
    #endregion

    #region Public methods
    public void SetSprite(Sprite newSprite)
    {
            elementImage.sprite = newSprite;
    }

    public void SetDistance(float distance)
    {
        string distanceText;
        if (distance > maxRepresentableDistance)
            distanceText = distanceOverflowText;
        else
            distanceText = distance.ToString("0");

        distanceLabel.text = distanceText;
    }
    #endregion
}
