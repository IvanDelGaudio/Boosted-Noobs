using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class CompassDisplay : MonoBehaviour
{
    #region Private variables
    [Header("Layout")]
    [SerializeField]
    private RectTransform compassElementsContainer;
    [Header("Prefabs")]
    [SerializeField]
    private CompassElement compassElementPrefab;
    [Header("Tuning")]
    [SerializeField]
    [Tooltip("How many degrees the compass covers from side to side")]
    [Range(10.0f, 360.0f)]
    private float compassFieldOfView = 180.0f;
    private List<CompassElement> compassElements = new List<CompassElement>();
    private Transform referenceTransform = null;
    #endregion
    #region Private properties
    private Transform compassPointOfView => referenceTransform ?? Camera.main.transform;
    #endregion
    #region Lifecycle
    void LateUpdate()
    {
        RefreshElements();
    }
    #endregion
    #region Public methods
    public void SetReferenceTransform(Transform newReferenceTransform) => referenceTransform = newReferenceTransform;
    public void ClearReferenceTransform() => SetReferenceTransform(null);
    public void RegisterCompassElement(CompassElementData elementData)
    {
        CompassElement compassElementInstance = Instantiate<CompassElement>(compassElementPrefab);
        compassElementInstance.referencedTransform = elementData.targetTransform;
        compassElementInstance.transform.SetParent(compassElementsContainer, false);
        compassElements.Add(compassElementInstance);
        compassElementInstance.SetSprite(elementData.elementSprite);
    }

    public void AddNewMark(Transform obj, Sprite sprite)
    {
        RegisterCompassElement(new CompassElementData
        {
            targetTransform = obj,
            elementSprite = sprite
        });
    }

    public void UnregisterTransform(Transform target)
    {
        CompassElement toRemove = compassElements.FirstOrDefault<CompassElement>(el => el.referencedTransform == target);

        if (toRemove == null)
            return;

        compassElements.Remove(toRemove);
        Destroy(toRemove.gameObject);
    }
    #endregion
    #region Private methods
    private bool GetSpatialInfo(Transform point, out float angle, out float distance)
    {
        if (point == null)
        {
            angle = 0.0f;
            distance = 0.0f;
            return false;
        }

        Vector3 relativePosition = point.position - compassPointOfView.position;
        relativePosition.y = 0.0f;

        distance = relativePosition.magnitude;

        Vector3 forward = compassPointOfView.forward;
        forward.y = 0.0f;

        angle = Vector3.SignedAngle(forward, relativePosition, Vector3.up);

        return true;
    }
    private void RefreshElements()
    {
        for (int i = 0; i < compassElements.Count; i++)
        {
            if (compassElements[i] == null)
                continue;

            if (compassElements[i].referencedTransform == null)
            {
                compassElements[i].visibility = 0.0f;
                continue;
            }

            //	Claculate angle and placement
            float angle, distance;
            if (!GetSpatialInfo(compassElements[i].referencedTransform, out angle, out distance))
            {
                compassElements[i].visibility = 0.0f;
                continue;
            }

            float compassExtent = compassFieldOfView * 0.5f;
            float normalizedPosition = Mathf.InverseLerp(-compassExtent, compassExtent, angle) * 2.0f - 1.0f;   //	Mapped to the [-1, 1] range left to right

            //	Set element's visibility
            compassElements[i].visibility = 1.0f - Mathf.Abs(normalizedPosition);

            //	Place on the compass, according to the angle
            (compassElements[i].transform as RectTransform).anchoredPosition = Vector2.right * normalizedPosition * compassElementsContainer.rect.width * 0.5f;

            //	Display the distance from the target
            compassElements[i].SetDistance(distance);
        }
    }
    #endregion
}
