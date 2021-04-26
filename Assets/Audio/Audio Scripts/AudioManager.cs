using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sfx[] sounds;

    
    public AudioMixer audioMixer1;

    
    public AudioMixerGroup sfxaudioMixer;


    public Music[] music;

    
    public AudioMixerGroup musicaudioMixer;

    public static AudioManager instance;


    // Creates a public list of sounds which can be called from other scripts
    public void Awake()
    {
        // This checks if there is more than one instance of the Audio Manager in the scene and leaves only one
        if (instance == null)
            instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //Assigns an AudioSource for every sound and declares the different var to each sound in the collection
        foreach (Sfx s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.priority = s.priority;

            s.source.outputAudioMixerGroup = sfxaudioMixer;


        }
        foreach (Music m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.musicClip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
            m.source.playOnAwake = m.PlayOnAwake;
            m.source.priority = m.priority;

            m.source.outputAudioMixerGroup = m.musicMixerGroup;


        }


    }

    // Returns no value if the sound cannot be found
    public void Play(string name)
    {
        //Debug.Log("Play " + name);

        Sfx s = Array.Find(sounds, sound => sound.name == name);
        Music m = Array.Find(music, music => music.name == name);


        if (m == null && s == null)
        {
            Debug.Log("Sound" + name + "Not Found");
            return;
        }
        else if (m == null && s != null)
        {

            if (s.clipsArray.Length > 0)
            {
                s.source.clip = (s.RandomCliptoPlay());
                s.source.Play();
            }

            if (s != null)
            {
                s.source.Play();
            }


        }
        else if (m != null && s == null)
        {

            if (m.musicArray.Length > 0)
            {
                m.source.clip = (m.RandomMusictoPlay());
                m.source.Play();
            }
            if (m != null)
            {
                m.source.Play();
            }

        }
    }
}
