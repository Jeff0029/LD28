using UnityEngine;
using System.Collections;

public class SpawnWaterDrop : MonoBehaviour {

    public GameObject waterDropPrefab;
    public Transform hitLocation;
    public float secondsPerDrop;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(DropWater());
	}
	
	IEnumerator DropWater()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsPerDrop);
            waterDropPrefab.GetComponent<Fall>().hitLocation = hitLocation;
            Instantiate(waterDropPrefab, transform.position, transform.rotation);
        }
    }
}
