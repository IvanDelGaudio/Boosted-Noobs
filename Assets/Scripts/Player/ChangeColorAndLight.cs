using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAndLight : MonoBehaviour
{
    #region Public Variables
    public Light light;
    public Renderer button;
    public Material MaterialGreenButton;
    public KeyCheck door;
    #endregion
    #region Private Variables
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods


    private void Update()
    {
        ColorAndLight();
    }

    public void ColorAndLight()
    {
        if (door.requiredKey == true)
        {
            light.color = Color.green;
          
            button.material = MaterialGreenButton;
        }
        
    }



    #endregion
    #region Private Methods
    #endregion
}
