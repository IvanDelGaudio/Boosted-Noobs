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
    public AudioClip clip;
    public Vector3 positionObject;
    public dimentionSFX dimention = dimentionSFX.dimention2D;
    #endregion
    #region Private Variables
    private AudioSource audioSource;
    #endregion
    #region Lifecycle
    #endregion
    #region Public Methods
    public void PlaySFX()
    { 
    switch (dimention)
                {
    case dimentionSFX.dimention3D:
    Play3DSound(clip, mixerGroup, positionObject,false);
    break;
    case dimentionSFX.dimention2D:
    Play2DSound(clip, mixerGroup, false);
    break;
                }
    }
    #endregion
}
