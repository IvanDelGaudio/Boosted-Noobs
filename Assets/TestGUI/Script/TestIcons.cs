using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TestIcons : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private IconsManager icons;
    #endregion

    #region Cycle Life
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            icons.ToggleKeyIcon();
        }

        if (Input.GetMouseButtonDown(1))
        {
            icons.ToggleFuseIcon();
        }

        if (Input.GetMouseButtonDown(2))
        {
            icons.UntoggleFuseIcon();
        }
    }
    #endregion
}
