using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX : SoundControls
    {
    public enum dimentionSFX : byte
    {
        dimention3D = 1,
        dimention2D = 2
    }
    #region Public Variables
    public AudioMixerGroup mixerGroup;
    public AudioClip[] audioClip;
    public Transform positionObject;
    public dimentionSFX dimention = dimentionSFX.dimention2D;
    [NonSerialized]
    public AudioSource audioSource;
    #endregion
    #region Private Variables
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods
    public void PlaySFX(int i)
    { 
    switch (dimention)
                {
        case dimentionSFX.dimention3D:
        if (audioSource == null)
        {
            audioSource = Play3DSound(audioClip[i], mixerGroup, positionObject.position, false);
        }
        break;
        case dimentionSFX.dimention2D:
        if (audioSource == null)
        {
            audioSource = Play2DSound(audioClip[i], mixerGroup, false);
        }
        break;
        }
    }
    #endregion
}
