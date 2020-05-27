using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SfxManager : MonoBehaviour
{
    public Audion[] sounds;
    public int songCode;
    [Range(0f, 1f)]
    public float tttD = 0.8f;
    public bool spetialCurve;
    public int serial;

    private void Awake()
    {
        foreach (Audion s in sounds)
        {
            if (spetialCurve == false)
                s.source = gameObject.AddComponent<AudioSource>();
            else
                s.source = gameObject.GetComponent<AudioSource>();

            s.source.spatialBlend = tttD;
            s.source.playOnAwake = false;

            s.source.clip = s.clip;

            s.source.volume = s.volume * PlayerPrefs.GetFloat("GlovalSfx");
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void VolChange()
    {
        foreach (Audion s in sounds)
            s.source.volume = s.volume * PlayerPrefs.GetFloat("GlovalSfx");
    }
    public void Play(string name)
    {

        Audion s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (spetialCurve == true)
            {
                serial = int.Parse(name) - 1;
                gameObject.GetComponent<AudioSource>().clip = sounds[serial].clip;
            }
            if (s != null)
                s.source.Play();
            //print(name);
        }
        else print("no Audion found");

    }
}
