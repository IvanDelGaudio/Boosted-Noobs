using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class RenderPipelineManager : MonoBehaviour
{
    public RenderPipelineAsset newRenderPipelineAsset;

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
        GraphicsSettings.renderPipelineAsset = null;  // Set to None when disabled
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        GraphicsSettings.renderPipelineAsset = newRenderPipelineAsset;  // Set to new render pipeline asset
    }
}

