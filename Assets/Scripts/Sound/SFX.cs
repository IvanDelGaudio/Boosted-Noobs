using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound{
public class SFX : SoundControls
    {
    #region Public 
        enum World : byte
        {
            dimention3,
            dimention2
            
        }
    private AudioSource audioSource;
    public AudioMixerGroup mixerGroup;
    public AudioClip clip;
    #endregion
    #region Private Variables
    SoundControls sourceControls;
    #endregion
    #region Lifecycle
    private void Awake()
    {
        sourceControls = GameObject.Find("SoundManager").GetComponent<SoundControls>();
    }
    #endregion
    #region Public Methods
    public void PlaySFX()
    {
        if (audioSource != null)
            return;
        audioSource = sourceControls.Play2DSound(clip, mixerGroup,false);
    }

    #endregion
    #region Private Methods
    #endregion
        }
    }

