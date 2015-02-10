using UnityEngine;
using System.Collections;

public class SeekPlayer : MonoBehaviour {

    private Transform target;
    public Transform Target
    {
        set 
        {
            target = value;
            StartCoroutine(TrackTarget());
        }

    }
    public float speed;
    public float maxSpeed;
    public float attackDistance;
    public AudioClip[] targetedPlayerRoar;
    public AudioClip[] seekingPlayerRoars;
    public AudioClip[] seekingPlayerKill;
    public float roarsIntervalTime;
    public GameObject AudioSpherePrefab;

	IEnumerator TrackTarget()
    {
        SoundLogic.EmitSound(transform, 15f, targetedPlayerRoar, GetComponent<AudioSource>(), 3, AudioSpherePrefab);
        StartCoroutine(GenerateSound(roarsIntervalTime));
        while (Vector3.Distance(transform.position, target.position) >= attackDistance)
        {

            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            if (maxSpeed > rigidbody.velocity.magnitude)
                rigidbody.AddForce(transform.forward * speed);

            yield return new WaitForFixedUpdate();
        }
        SoundLogic.EmitSound(transform, 15f, seekingPlayerKill, GetComponent<AudioSource>(), 3, AudioSpherePrefab);
        StartCoroutine(KillBox.TimeframeUntilRespawn(1, target.gameObject));
    }

    IEnumerator GenerateSound(float interval)
    {
        while (enabled)
        {
            yield return new WaitForSeconds(interval);
            SoundLogic.EmitSound(transform, 15f, seekingPlayerRoars, GetComponent<AudioSource>(), 3, AudioSpherePrefab);
        }
    }
}
