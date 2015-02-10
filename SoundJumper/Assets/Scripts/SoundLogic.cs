using UnityEngine;
using System.Collections;

public class SoundLogic : MonoBehaviour {

    static AudioClip RandomSoundClip(AudioClip[] sounds)
    {
        return sounds[Random.Range(0, sounds.Length - 1)];
    }
    
    public static void  EmitSound(Vector3 position, float strenght, AudioClip[] colliderSounds, AudioSource collisionSoundSource, float minSoundDistance, GameObject visibleSoundSpherePrefab)
    {
        AudioClip clip = RandomSoundClip(colliderSounds);
        float velocityModifier = strenght / 12;
        
        collisionSoundSource.clip = clip;
        collisionSoundSource.volume = Mathf.Max(0.6f, velocityModifier);
        collisionSoundSource.maxDistance = Mathf.Min(minSoundDistance, velocityModifier);
        collisionSoundSource.Play();
        
        visibleSoundSpherePrefab.GetComponent<SoundFadeAway>().size = strenght;
        visibleSoundSpherePrefab.GetComponent<SoundFadeAway>().timer = clip.length + 0.5f;
        Instantiate(visibleSoundSpherePrefab, position, Quaternion.identity);
        
    }

    public static void  EmitSound(Transform target, float strenght, AudioClip[] colliderSounds, AudioSource collisionSoundSource, float minSoundDistance, GameObject visibleSoundSpherePrefab)
    {
        AudioClip clip = RandomSoundClip(colliderSounds);
        float velocityModifier = strenght / 12;
        
        collisionSoundSource.clip = clip;
        collisionSoundSource.volume = Mathf.Max(0.6f, velocityModifier);
        collisionSoundSource.maxDistance = Mathf.Min(minSoundDistance, velocityModifier);
        collisionSoundSource.Play();
        
        visibleSoundSpherePrefab.GetComponent<SoundFadeAway>().size = strenght;
        visibleSoundSpherePrefab.GetComponent<SoundFadeAway>().timer = clip.length + 0.5f;
        GameObject soundSphere = (GameObject)Instantiate(visibleSoundSpherePrefab, target.position, target.rotation);

        soundSphere.transform.parent = target;
    }
}
