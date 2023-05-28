using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> sfxClips;

    public void GetWood()
    {
        sfxSource.clip = sfxClips[0];
        sfxSource.Play();
    }

    public void GetFood()
    {
        sfxSource.clip = sfxClips[1];
        sfxSource.Play();
    }

    public void GetWound()
    {
        sfxSource.clip = sfxClips[2];
        sfxSource.Play();
    }

    public void GetWin()
    {
        bgmSource.clip = sfxClips[3];
        bgmSource.Play();
    }

    public void GetLose()
    {
        bgmSource.clip = sfxClips[4];
        bgmSource.Play();
    }
}
