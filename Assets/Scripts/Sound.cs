using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public string name; 
    public AudioClip audioClip;
    [Range(0f, 10f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    public AudioMixerGroup output;
    [HideInInspector]
    public AudioSource source;
    
}
