using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Seting")]
    [Range(0f, 1f)]

    public float musicvolums;
    [Range(0f, 1f)]

    public float vfsvolume;

    public AudioSource msAus;
    public AudioSource Vfxaus;

    public AudioClip shootting;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip[] bgmusic;

    public override void Start()
    {
        PlayMusic(bgmusic);
    }
    public void playSound( AudioClip sound , AudioSource aus = null)
    {
        if(!aus)
        {
            aus = Vfxaus;
        }

        if(aus) {
            aus.PlayOneShot(sound, vfsvolume);

        }
    }

    public void Playsound(AudioClip[] sounds, AudioSource aus = null)
    {
        if(!aus)
        {
            aus = Vfxaus;
        }
        if(aus)
        {
            int randomsoudn = Random.Range(0, sounds.Length);

            if (sounds[randomsoudn] != null)
            {
                aus.PlayOneShot(sounds[randomsoudn], vfsvolume);
            }
        }
    }

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (msAus)
        {
            msAus.clip= music;
            msAus.loop= loop;
            msAus.volume = musicvolums;
            msAus.Play();
        }
    }

    public void PlayMusic(AudioClip[] musics, bool loop = true)
    {
        if (msAus)
        {
            int random = Random.Range(0, musics.Length);

            if (musics[random] != null)
            {
                msAus.clip= musics[random];
                msAus.loop= loop;
                msAus.volume = musicvolums;
                msAus.Play();
            }
        }
    }
}
