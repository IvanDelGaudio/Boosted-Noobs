using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class SFX : SoundControls
    {
        #region Public Variables
        public int dimention3D;
        private AudioSource audioSource;
        public AudioMixerGroup mixerGroup;
        public AudioClip clip;
        public Vector3 positionObject;
        #endregion
        #region Private Variables
        SoundControls sourceControls;
        #endregion
        #region Lifecycle
    private void Awake()
    {
        sourceControls = GameObject.Find("SoundManager").GetComponent<SoundControls>();
    }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                PlaySFX();
        }
        #endregion
        #region Public Methods
        public void PlaySFX()
        {
                switch (dimention3D)
                {
                    case 1:
                    Play3DSound(clip, mixerGroup, positionObject,false);
                    break;

                    case 2:
                    Play2DSound(clip, mixerGroup, false);
                    break;
                        }
        }

        #endregion
        #region Private Methods
        #endregion
    }
}
