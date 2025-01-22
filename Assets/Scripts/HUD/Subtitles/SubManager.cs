using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubManager : MonoBehaviour
{
    #region Public Variables
    public GameObject subtitlePanel;
    public TextMeshProUGUI subtitleText;
    public SubPhrasesList phraseData;
    public float wordDisplayDelay = 0.5f;

    private Queue<string> wordsQueue;
    private Coroutine subtitleCoroutine;
    #endregion

    #region Cycle Life
    void Start()
    {
        subtitlePanel.SetActive(false);
        subtitleText.text = string.Empty;
    }
    #endregion

    #region Public Methods
    public void StartSubtitles(int phraseIndex)
    {
        if (phraseIndex < 0 || phraseIndex >= phraseData.phrases.Length)
        {
            Debug.LogError("Phrase index out of bounds");
            return;
        }

        wordsQueue = new Queue<string>(phraseData.phrases[phraseIndex].Split(' '));
        if (subtitleCoroutine != null)
        {
            StopCoroutine(subtitleCoroutine);
        }
        subtitlePanel.SetActive(true);
        subtitleCoroutine = StartCoroutine(DisplaySubtitles());
    }

    public void StopSubtitles()
    {
        if (subtitleCoroutine != null)
        {
            StopCoroutine(subtitleCoroutine);
        }
        subtitlePanel.SetActive(false);
        subtitleText.text = string.Empty;
    }

    private IEnumerator DisplaySubtitles()
    {
        subtitleText.text = string.Empty;

        while (wordsQueue.Count > 0)
        {
            string word = wordsQueue.Dequeue();
            subtitleText.text += word + " ";
            yield return new WaitForSeconds(wordDisplayDelay);
        }

        subtitleCoroutine = null;
    }
    #endregion
}
