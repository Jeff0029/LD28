using UnityEngine;
using System.Collections;

public class SoundFadeAway : MonoBehaviour {

    public float size;
    public float timer;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, timer);
        transform.localScale = new Vector3(size, size, size);
        StartCoroutine(FadeAway(renderer.material, timer));
	}
	
	public static IEnumerator FadeAway(Material mat, float time)
    {
        float startingAlpha = mat.color.a;
        float timer = 0;

        while (timer <= 1)
        {
            timer += (Time.deltaTime/ time);

            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Mathf.Lerp(startingAlpha, 0, timer));
            yield return null;
        }
    }
}
