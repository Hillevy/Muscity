using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {

    public AudioClip reverb;
    public AudioClip muffle;
    public AudioClip evening;
    public AudioClip night;
    public AudioClip wind;

    private AudioSource audio;
    private float t = 0.0f;
    private bool b_reverb = true;
    private bool b_muffle = true;
    private bool b_evening = true;
    private bool b_night = true;
    private bool b_wind = true;


    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        //Louder noises
        if (Time.time > 60.0f)
        {
            audio.volume = Mathf.Lerp(0.5f, 0.8f, t);
            t += 0.002f;
        }

        //Reverbed noises
        if (Time.time > 60*2 && b_reverb)
        {
            audio.clip = reverb;
            audio.Play();
            b_reverb = false;
        }

        //Muffled noises
        if (Time.time > 60*3 && b_muffle)
        {
            audio.clip = muffle;
            audio.Play();
            b_muffle = false;
        }

        //evening noises
        if (Time.time > 60*5 && b_evening)
        {
            audio.clip = evening;
            audio.Play();
            b_evening = false;
        }

        //night noises
        if (Time.time > 60 * 8 && b_night)
        {
            audio.clip = night;
            audio.Play();
            b_night = false;
        }

        //Creepy wind
        if (Time.time > 60 * 10 && b_wind)
        {
            audio.clip = wind;
            audio.Play();
            b_wind = false;
        }
    }
}
