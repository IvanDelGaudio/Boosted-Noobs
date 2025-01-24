using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[DisallowMultipleComponent]
public class CanvasManager : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Canvas canvasToActivate;
    [SerializeField]
    private Canvas canvasToDeactivate;
    [SerializeField]
    private VideoPlayer videoPlayer;
    #endregion

    #region Cycle Life
    void Start()
    {
        canvasToActivate.gameObject.SetActive(false);
        canvasToDeactivate.gameObject.SetActive(true);

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    #endregion

    #region Private Methods
    private void OnVideoEnd(VideoPlayer vp)
    {
        canvasToDeactivate.gameObject.SetActive(false);
        canvasToActivate.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
    #endregion
}
