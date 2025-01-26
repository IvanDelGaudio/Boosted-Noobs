using UnityEngine;

public class ResetShadersToDefault : MonoBehaviour
{
    private Shader defaultShader;

    private void Awake()
    {
        if (defaultShader == null)
        {
            defaultShader = Shader.Find("Standard");
        }

        Renderer[] renderers = FindObjectsOfType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                mat.shader = defaultShader;
            }
        }

        Debug.Log("All shaders have been reset to the default shader.");
    }
}
