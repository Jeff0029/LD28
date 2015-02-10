using UnityEngine;
using System.Collections;

public class FadeAwayBG : MonoBehaviour {

    public AudioSource musicToStop;
    public float timer;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(fadeAwayVolume());
        }
    }

    IEnumerator fadeAwayVolume()
    {
        while (musicToStop.volume > 0)
        {
            musicToStop.volume -= (1 / timer) * Time.deltaTime;
            yield return null;
        }
    }
}
