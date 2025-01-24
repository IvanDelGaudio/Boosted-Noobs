using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SetURPForThisScene : MonoBehaviour
{
    [SerializeField]
    public UniversalRenderPipelineAsset urpAsset;

    void OnEnable()
    {
        if (urpAsset != null)
        {
            GraphicsSettings.renderPipelineAsset = urpAsset;
            QualitySettings.renderPipeline = urpAsset;
        }
    }

    void OnDisable()
    {
        GraphicsSettings.renderPipelineAsset = null;
        QualitySettings.renderPipeline = null;
    }
}
