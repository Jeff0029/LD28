using UnityEngine;
using System.Collections;


public class Fall : MonoBehaviour {

    public Transform hitLocation;
    public float speed;
    public float soundStrenght;
    public AudioClip[] dropSounds;
    public GameObject emptyAudioSourcePrefab;
    public GameObject soundSpherePrefab;

	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (hitLocation.position.y > transform.position.y)
        {
            DropletHit();
        }
	}

    void DropletHit()
    {
        SoundLogic.EmitSound(transform.position, soundStrenght, dropSounds, emptyAudioSourcePrefab.GetComponent<AudioSource>(), 0, soundSpherePrefab);
        Instantiate(emptyAudioSourcePrefab);
        Destroy(gameObject);
    }
}
