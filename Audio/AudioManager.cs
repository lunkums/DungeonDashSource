using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;
    private float masterVolume, ambientVolume, musicVolume;

    public float MasterVolume
    {
        get { return masterVolume; }
        set { masterVolume = value; UpdateSoundVolumes(); }
    }

    public float AmbientVolume
    {
        get { return ambientVolume; }
        set { ambientVolume = value; UpdateSoundVolumes(); }
    }

    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; UpdateSoundVolumes(); }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        masterVolume = 1.0f;
        ambientVolume = 1.0f;
        musicVolume = 1.0f;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
        UpdateSoundVolumes();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: [" + name + "] not found in sound array.");
        }
        else
        {
            s.source.Play();
        }
    }

    private void UpdateSoundVolumes()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = 1.0f * masterVolume * GetSoundType(s);
        }
    }

    private float GetSoundType(Sound sound)
    {
        float soundType = 0f;
        Type type = sound.GetType();

        if (type == typeof(AmbientSound))
        {
            soundType = ambientVolume;
        }
        else if (type == typeof(MusicSound))
        {
            soundType = musicVolume;
        }
        return soundType;
    }
}
