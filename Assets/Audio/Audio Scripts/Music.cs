using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Music
{

    public string name;

    public AudioClip[] musicArray;

    public AudioClip musicClip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool PlayOnAwake;

    public int priority;
    public AudioSource source;

    public AudioMixerGroup musicMixerGroup;

    public AudioClip RandomMusictoPlay()
    {

        int randomClipIndex = Random.Range(0, musicArray.Length);
        return musicArray[randomClipIndex];


    }



}

