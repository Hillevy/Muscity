using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManager : MonoBehaviour
{

    public AudioClip cat;
    public AudioClip angryCat;

    private AudioSource[] audio;
    private bool b_cat = true;
    private bool b_angryCat = true;
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
        if (Time.time > 60.0f * 5 && b_cat)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = cat;
                audio[i].Play();
            }
            b_cat = false;
        }

        if (Time.time > 60.0f * 10 && b_angryCat)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = angryCat;
                audio[i].Play();
            }
            b_angryCat = false;
        }

    }
}
