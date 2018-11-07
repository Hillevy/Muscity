using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkManager : MonoBehaviour
{

    public AudioClip reverb;
    public AudioClip muffle;

    private AudioSource audio;
    private float t = 0.0f;
    private bool b_reverb = true;
    private bool b_muffle = true;


    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Louder noises
        if (Time.time > 60.0f)
        {
            audio.volume = Mathf.Lerp(0.7f, 0.9f, t);
            t += 0.002f;
        }

        //Reverbed noises
        if (Time.time > 60.0f*2 && b_reverb)
        {
            t = 0f; //needed for Faded noises
            audio.clip = reverb;
            audio.Play();
            b_reverb = false;
        }

        //Muffled noises
        if (Time.time > 60.0f*3 && b_muffle)
        {
            audio.clip = muffle;
            audio.Play();
            b_muffle = false;
        }

        //Fading noises
        if (Time.time > 60*5)
        {
            audio.volume = Mathf.Lerp(audio.volume, 0f, t);
            t += 0.002f;
        }
    }
}
