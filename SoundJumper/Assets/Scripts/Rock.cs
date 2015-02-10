using UnityEngine;
using System.Collections;

[RequireComponent( typeof(AudioSource))]

public class Rock : MonoBehaviour {

    public AudioClip[] colliderSounds;
    AudioSource collisionSoundSource;
    public GameObject visibleSoundSphere;
    public float minSoundDistance;
    public float lifeSpan;

	// Use this for initialization
	void Start () 
    {
        collisionSoundSource = GetComponent<AudioSource>();
	}


    void OnCollisionEnter(Collision collider)
    {
        SoundLogic.EmitSound(collider.contacts[0].point, 10, colliderSounds, collisionSoundSource, minSoundDistance, visibleSoundSphere);
        Destroy(gameObject, lifeSpan);
    }
}
