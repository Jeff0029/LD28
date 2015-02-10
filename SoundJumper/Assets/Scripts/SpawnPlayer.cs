using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public delegate void PlayerRespawnDel();
    public event PlayerRespawnDel onPlayerRespawn;

    public GameObject playerPrefab;

    public static Transform spawnPointLocation;
    private static Transform respawnPointLocation;
    public Transform Respawn
    {
        get 
        { 
            Debug.Log("Invoke");
            InvokeSpawnEvent();
            return respawnPointLocation;
        }
    }
    public Transform respawnLocation;
	// Use this for initialization
	void Start () 
    {
        respawnPointLocation = respawnLocation;
        spawnPointLocation = transform;
        SpawnPlayerObj(playerPrefab, transform, this);
	}

    public void InvokeSpawnEvent()
    {
        if (onPlayerRespawn != null)
                onPlayerRespawn.Invoke();
    }

    public static void SpawnPlayerObj(GameObject prefab, Transform location, SpawnPlayer spawner)
    {

        GameObject player = (GameObject) Instantiate(prefab, location.position, location.rotation);

        player.GetComponent<Controler>().RespawnLocation = location;
        player.GetComponent<Controler>().spawner = spawner;
    }
}
