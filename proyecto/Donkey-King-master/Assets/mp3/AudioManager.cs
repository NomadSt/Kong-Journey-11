using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Audion[] sounds;
    public static AudioManager instance;
    public float timer;
    public int songCode;

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
        foreach(Audion s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume * PlayerPrefs.GetFloat("GlovalVol");
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        songCode = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play(songCode.ToString());
    }
    public void changeVol()
    {
        foreach (Audion s in sounds)
        {
            s.source.volume = s.volume * PlayerPrefs.GetFloat("GlovalVol");
        }
    }
    IEnumerator NextSong()
    {
        yield return new WaitForSeconds(timer);
        {
            songCode = Random.Range(1, 3);
            FindObjectOfType<AudioManager>().Play(songCode.ToString());
        }
    }

    public void Play(string name)
    {
        foreach(Audion se in sounds)
        {
            se.source.Stop();
        }
        Audion s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        timer = s.timer;
        StartCoroutine(NextSong());
    }
}
