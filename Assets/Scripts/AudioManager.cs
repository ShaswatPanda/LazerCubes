using UnityEngine.Audio;
using UnityEngine;
using System;



public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    

    void Start()
    {
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }
    }

    public void play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            return;
        }
        s.source.Play();
    }

    public void pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            return;
        }
        s.source.Pause();
    }


}
