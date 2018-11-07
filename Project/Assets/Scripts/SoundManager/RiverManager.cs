using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverManager : MonoBehaviour
{
    public AudioClip normal;
    public AudioClip reverb;
    public AudioClip muffle;
 
    private AudioSource[] audio;
    private float t = 0.0f;
    private bool b_normal = true;
    private bool b_reverb = true;
    private bool b_muffle = true;
    private bool b_normal2 = true;
    private int count;


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
        for (int i = 0; i < count; i++)
        {
            if (Time.time > 0.0f && b_normal)
            {
                audio[i].clip = normal;
                audio[i].Play();
                b_normal = false;
            }
            //Louder noises
            if (Time.time > 60.0f)
            {
                audio[i].volume = Mathf.Lerp(0.4f, 0.7f, t);
                t += 0.002f;
            }

            //Reverbed noises
            if (Time.time > 120.0f && b_reverb)
            {
                t = 0f; //needed for Faded noises
                audio[i].clip = reverb;
                audio[i].Play();
                b_reverb = false;
            }

            //Muffled noises
            if (Time.time > 180.0f && b_muffle)
            {
                audio[i].clip = muffle;
                audio[i].Play();
                b_muffle = false;
            }

            if (Time.time > 60.0f * 5 && b_normal2)
            {
                audio[i].clip = normal;
                audio[i].Play();
                b_normal2 = false;
            }
        }
    }
}
