using UnityEditor.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public Sound[] sounds;
    private float musicVolume = 0.5f;
    public static AudioManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
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

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Theme");
        audioSrc = gameObject.GetComponent<AudioSource>();
        Debug.Log(audioSrc.volume);
    }
    void Update()
    {
        audioSrc.volume = musicVolume;
        //Sound s = Array.Find(sounds, sound => sound.name == "theme");
        //s.source.volume = musicVolume;
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
    }
    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*public void ChangeVolume(float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "theme");
        s.source.volume = vol;
    }*/
    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
