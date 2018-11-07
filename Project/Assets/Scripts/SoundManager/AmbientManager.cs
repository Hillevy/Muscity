using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour {

    public AudioClip day;
    public AudioClip evening;
    public AudioClip earlyNight;
    public AudioClip lateNight;

    private AudioSource audio;
    private float t = 0.0f;
    private bool b_evening = true;
    private bool b_earlyNight = true;
    private bool b_lateNight = true;

    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = day;
        audio.Play();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Time.time > 60*4 && b_evening)
        {
            audio.clip = evening;
            audio.Play();
            b_evening = false;
        }

        if (Time.time > 60 * 7 && b_earlyNight)
        {
            audio.clip = earlyNight;
            audio.Play();
            audio.volume = 0.3f;
            b_earlyNight = false;
        }

        if (Time.time > 60*11 && b_lateNight)
        {
            audio.clip = lateNight;
            audio.Play();
            b_lateNight = false;
        }
        
    }
}
