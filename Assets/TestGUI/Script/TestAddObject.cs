using UnityEngine;

public class TestAddObject : MonoBehaviour
{
    public CompassDisplay compassDisplay;  // Reference to the CompassManager component
    public Transform newTarget;
    public Sprite newSprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            compassDisplay.AddNewMark(newTarget, newSprite);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            compassDisplay.UnregisterTransform(newTarget);
        }
    }
}
