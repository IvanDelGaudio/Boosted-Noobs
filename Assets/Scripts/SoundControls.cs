using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;


namespace Sound
{
    public class SoundControls : MonoBehaviour
    {
        #region Public Variables
        #endregion
        #region Private Variables
        private bool isSoundtrackPaused = false;
        private bool isSoundtrackPlaying = false;
        private AudioSource soundtrackSource;
        #endregion
        #region Lifecycle
        #endregion
        #region Public Methods       
        public AudioSource Play2DSound(AudioClip clip, AudioMixerGroup mixerGroup, bool persistent = false)
        {
            AudioSource source = PlayClipOnce(clip, mixerGroup,persistent);

            if (clip != null)
                source.spatialBlend = 0.0f;
            source.loop = persistent;
            return source;
        }
        public AudioSource Play3DSound(AudioClip clip, AudioMixerGroup mixerGroup, Vector3 position, bool persistent = false)
        {
            AudioSource source = PlayClipOnce(clip, mixerGroup,persistent);

            if (clip != null)
            {
                source.spatialBlend = 1.0f;
                source.transform.position = position;
            }
            source.loop = persistent;
            return source;
        }
        public AudioSource PlayMusic(AudioClip clip, AudioMixerGroup mixerGroup)
        {
            AudioSource source = Play2DSound(clip, mixerGroup, true);

            if (source != null)
                source.loop = true;

            return source;
        }
        #endregion
        #region Private Methods
        private AudioSource CreateAudioSource(AudioClip clip, bool loop)
        {
            if (clip == null) 
                return null;

            GameObject audioSourceGO = new GameObject($"Audio Souce {clip.name}");
            AudioSource audioSource = audioSourceGO.AddComponent<AudioSource>();

            if (loop == false)
            {
                Object.Destroy(audioSourceGO,clip.length);
            }
            return audioSource;
        }
        private AudioSource PlayClipOnce(AudioClip clip, AudioMixerGroup output,bool persistent=false)
        {
            AudioSource source = CreateAudioSource(clip, persistent);

            if (clip == null)
                return null;

            source.outputAudioMixerGroup = output;
            source.clip = clip;

            source.Play();

            return source;
        }
        #endregion
    }
}