using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportManager : MonoBehaviour {

    public AudioClip plane;
    public AudioClip train;

    private AudioSource audio;
    private bool b_plane = true;
    private bool b_train = true;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();	
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.time > 60*7 && b_plane)
        {
            audio.clip = plane;
            audio.Play();
            b_plane = false;
        }

        if (Time.time > 60 * 8 && b_train)
        {
            audio.clip = train;
            audio.Play();
            b_train = false;
        }
    }
}
