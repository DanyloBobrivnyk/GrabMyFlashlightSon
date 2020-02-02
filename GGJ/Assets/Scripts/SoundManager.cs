using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private Audio[] _audioArray = Array.Empty<Audio>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    public void PlaySound(string audioName)
    {
        foreach (var sound in _audioArray)
        {
            if (audioName == sound.name)
            {
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                if (sound.randomPitch)
                {
                    sound.source.pitch = Random.Range(.8f, 1.2f);
                }
                else
                {
                    sound.source.pitch = sound.pitch;
                }
                if (sound.playOnAwake)
                {
                    sound.source.playOnAwake = true;
                }
                if (sound.loop)
                {
                    sound.source.loop = true;
                }
                sound.source.Play();
            }
        }
    }
    private void Start()
    {
        PlaySound("background");
    }
}
[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;
    public AudioSource source;
    [Range(0, 1)] public float volume;
    [Range(-3, 3)] public float pitch;
    public bool playOnAwake;
    public bool loop;
    public bool randomPitch;
}
