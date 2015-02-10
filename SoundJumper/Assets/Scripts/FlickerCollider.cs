using UnityEngine;
using System.Collections;

public class FlickerCollider : MonoBehaviour {

    public float flickerPerSec;
    public Collider colliderToFlicker;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Flicker());
	}
	
	IEnumerator Flicker()
    {
        while (true)
        {
            colliderToFlicker.enabled = true;
            yield return new WaitForSeconds(1/flickerPerSec);
            colliderToFlicker.enabled = false;
        }
    }
}
