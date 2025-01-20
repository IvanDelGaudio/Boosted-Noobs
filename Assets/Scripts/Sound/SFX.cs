using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
    {
        public class SFX : SoundControls
        {
            #region Public Variables
            [Header("SFX")]
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
            private void Start()
            {
                PlayBGM();
            }
            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.A))
                    StopBGM();
                if (Input.GetKeyDown(KeyCode.B))
                    ResumeBGM();
                if (Input.GetKeyDown(KeyCode.C))
                    DestroyBGM();
                if (Input.GetKeyDown(KeyCode.D))
                    PlayBGM();
            }
            #endregion
            #region Public Methods
            public void PlayBGM()
            {
                if (audioSource != null)
                    return;
                audioSource = sourceControls.PlayMusic(clip, mixerGroup);
            }
            public void StopBGM()
            {
                audioSource.Pause();
                return;
            }
            public void ResumeBGM()
            {
                audioSource.Play();
            }
            public void DestroyBGM()
            {
                Destroy(audioSource.gameObject);
            }
            #endregion
            #region Private Methods
            #endregion
        }
    }

