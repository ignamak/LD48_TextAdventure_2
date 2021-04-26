using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sfx
{
    public string name;

    public AudioClip[] clipsArray;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public int priority;

    public AudioSource source;

    public AudioClip RandomCliptoPlay()
    {

        int randomClipIndex = Random.Range(0, clipsArray.Length);
        return clipsArray[randomClipIndex];
    }
}



