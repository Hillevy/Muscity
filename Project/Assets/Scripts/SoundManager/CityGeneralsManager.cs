using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGeneralsManager : MonoBehaviour
{

    public AudioClip reverb;
    public AudioClip muffle;
    public AudioClip evening;
    public AudioClip night;
    public AudioClip wind;

    private AudioSource[] audio;
    private float t = 0.0f;
    private int count;
    private bool b_reverb = true;
    private bool b_muffle = true;
    private bool b_evening = true;
    private bool b_night = true;
    private bool b_wind = true;


    // Use this for initialization
    void Start()
    {
        count = transform.childCount;
        audio = new AudioSource[count];
        getAllAudioSource();
    }

    void getAllAudioSource()
    {
        for (int i = 0; i < count; i++)
        {
            audio[i] = transform.GetChild(i).GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Louder noises
        if (Time.time > 60.0f)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].volume = Mathf.Lerp(0.7f, 0.8f, t);
                t += 0.002f;
            }
        }

        //Reverbed noises
        if (Time.time > 60 * 2 && b_reverb)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = reverb;
                audio[i].Play();
                
            }
            b_reverb = false;
        }

        //Muffled noises
        if (Time.time > 60 * 3 && b_muffle)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = muffle;
                audio[i].Play();
                
            }
            b_muffle = false;
        }

        //evening noises
        if (Time.time > 60 * 5 && b_evening)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = evening;
                audio[i].Play();
                
            }
            b_evening = false;
        }

        //night noises
        if (Time.time > 60 * 8 && b_night)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = night;
                audio[i].Play();
                
            }
            b_night = false;
        }

        //Creepy wind
        if (Time.time > 60 * 10 && b_wind)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = wind;
                audio[i].Play();
                
            }
            b_wind = false;
        }
    }
}
