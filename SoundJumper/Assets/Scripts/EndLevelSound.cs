using UnityEngine;
using System.Collections;

[RequireComponent( typeof (AudioSource))]

public class EndLevelSound : MonoBehaviour {

    public AudioClip clip;
    AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            soundSource.clip = clip;
            soundSource.Play();
        }
    }
}
