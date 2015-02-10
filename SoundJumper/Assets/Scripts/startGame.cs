using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour 
{
    public AudioClip clickSound;

	void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        StartCoroutine(DelayUntilLoad(clickSound.length));
    }  

    IEnumerator DelayUntilLoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel("Level1");
    }
}
