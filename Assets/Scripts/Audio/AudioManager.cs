using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    [Range(0f, 1f)]
    public float sfxMaster, musicMaster;

    public float prevMusicVolume;
    public float prevSfxVolume;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        AdjustSoundVolume();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        Debug.Log("Sound: " + name + " is playing.");
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        Debug.Log("Sound: " + name + " stopped.");
        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    public Sound GetSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        return s;
    }

    public void StopAll()
    {
        foreach(Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }

    public void AdjustSoundVolume()
    {
        foreach (Sound s in sounds)
        {
            if(s.isMusic)
            {
                s.source.volume = s.volume * musicMaster;
            }
            else
            {
                s.source.volume = s.volume * sfxMaster;
            }
        }
    }
    public float GetMusicMaster()
    {
        return musicMaster;
    }

    public float GetSoundMaster()
    {
        return sfxMaster;
    }
}
