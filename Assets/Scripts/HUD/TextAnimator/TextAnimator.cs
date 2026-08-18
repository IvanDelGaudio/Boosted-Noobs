using TMPro;
using UnityEngine;

public class WaveTextAnimator : MonoBehaviour
{
    #region Private Variables
    [Header("Data")]
    [SerializeField]
    private TMP_Text text;
    [Header("Settings")]
    [SerializeField]
    private float amplitude = 0.5f;
    [SerializeField]
    private float frequency = 2f;
    [SerializeField]
    private float speed = 1f;

    private TMP_TextInfo textInfo;
    private Vector3[] originalVertices;
    #endregion

    #region Cycle Life
    private void Update()
    {
        if (text.gameObject.activeInHierarchy)
        {
            if (originalVertices == null || originalVertices.Length == 0)
            {
                AssignText();
            }
            AnimateWave();
        }
    }
    #endregion

    #region Public Methods
    private void AssignText()
    {
        text.ForceMeshUpdate();
        textInfo = text.textInfo;
        originalVertices = new Vector3[textInfo.meshInfo[0].vertices.Length];

        for (int i = 0; i < textInfo.meshInfo[0].vertices.Length; i++)
        {
            originalVertices[i] = textInfo.meshInfo[0].vertices[i];
        }
    }
    #endregion

    #region Private Methods
    private void AnimateWave()
    {
        text.ForceMeshUpdate();
        textInfo = text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                Vector3 offset = originalVertices[vertexIndex + j];
                offset.y += Mathf.Sin(Time.time * speed + i * frequency) * amplitude;
                vertices[vertexIndex + j] = offset;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            text.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
    #endregion
}
