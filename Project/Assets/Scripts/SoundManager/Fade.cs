using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    private AudioSource audio;
    private float t = 0.0f;

    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();	
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Time.time > 60 * 6)
        {
            audio.volume = Mathf.Lerp(audio.volume, 0.0f, t);
            t += 0.002f;
        }
    }
}
