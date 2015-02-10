using UnityEngine;
using System.Collections;

public class ActivateSpawner : MonoBehaviour {

    bool spawnOnce = true;
    public SpawnEnemy[] spawners;
    public SpawnPlayer playerSpawn;

    void Start()
    {
        playerSpawn.onPlayerRespawn += ResetSpawn;
    }

    void ResetSpawn()
    {
        spawnOnce = true;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && spawnOnce)
        {
            for(int i = 0; i < spawners.Length; i++)
            {
                spawners[i].Spawn();
            }
            spawnOnce = false;
        }
    }
}
