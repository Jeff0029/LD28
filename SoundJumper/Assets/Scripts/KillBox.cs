using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    public float timeBeforeRespawn;
    public AudioClip dyingSound;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(dyingSound, Vector3.zero, 0.2f);
            StartCoroutine(TimeframeUntilRespawn(timeBeforeRespawn, other.gameObject));
        }
    }

    public static IEnumerator TimeframeUntilRespawn(float time, GameObject deadPlayer)
    {
        yield return new WaitForSeconds(time);
        Transform respawn = deadPlayer.GetComponent<Controler>().RespawnLocation;
        deadPlayer.transform.position = respawn.position;
        deadPlayer.transform.rotation = respawn.rotation;
        deadPlayer.rigidbody.velocity = Vector3.zero;
    }
}
