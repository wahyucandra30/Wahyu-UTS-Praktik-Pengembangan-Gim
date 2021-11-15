// ================================================================================================================
// UTS Praktik - AudioManager.cs
// 
// Author: Wahyu Candra
// Date:   12/11/2021
// ================================================================================================================
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    private struct Sound
    {
        [SerializeField] private string soundName;
        [SerializeField] private AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(-3f, 3f)]
        [SerializeField] private float pitch;

        public string GetName() => soundName;
        public AudioClip GetClip() => clip;
        public float GetVolume() => volume;
        public float GetPitch() => pitch;
    }

    [SerializeField] private List<Sound> soundList;
    private List<AudioSource> sourceList;

    private void Awake()
    {
        sourceList = new List<AudioSource>();
    }
    private void Start()
    {
        foreach(Sound sound in soundList)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.name = sound.GetName();
            source.clip = sound.GetClip();
            source.volume = sound.GetVolume();
            source.pitch = sound.GetPitch();

            sourceList.Add(source);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        foreach(AudioSource source in sourceList)
        {
            if(source.clip.Equals(clip))
            {
                source.Play();
            }
        }
    }
}
