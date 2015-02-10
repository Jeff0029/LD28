using UnityEngine;
using System.Collections;

public class DestroyOnFinish : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
	}
}
