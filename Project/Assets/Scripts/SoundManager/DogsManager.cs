using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsManager : MonoBehaviour {

    public AudioClip dog;
    public AudioClip wolf;

    private AudioSource[] audio;
    private bool b_dog = true;
    private bool b_wolf = true;
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
        if (Time.time > 60.0f * 6 && b_dog)   
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = dog;
                audio[i].Play();
                audio[i].loop = true;
            }
            b_dog = false;
        }

        if (Time.time > 60.0f * 9 && b_wolf)
        {
            for (int i = 0; i < count; i++)
            {
                audio[i].clip = wolf;
                audio[i].Play();
                audio[i].loop = false;
            }
            b_wolf = false;
        }

    }
}
