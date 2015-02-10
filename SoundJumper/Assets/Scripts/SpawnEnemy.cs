using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemyPrefab;
    bool isEnemyInstantiate = false;
    public SpawnPlayer playerSpawn;
    GameObject obj;
    public void Start()
    {
        playerSpawn.onPlayerRespawn += Reset;
    }

    public void Reset()
    {
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(false);
        }
    }

    public void Respawn()
    {
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
    }

	public void Spawn()
    {
        if (isEnemyInstantiate)
            Respawn();
        else
        {
            obj = (GameObject)Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemyPrefab = obj;
            enemyPrefab.SetActive(true);
            isEnemyInstantiate = true;
        }
    }
}
