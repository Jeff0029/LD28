using UnityEngine;
using System.Collections;

[RequireComponent( typeof(AudioSource))]

public class OneTimePlay : MonoBehaviour {

    public AudioClip clip;
    AudioSource source;


	// Use this for initialization
	void Start () 
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
	}
}
