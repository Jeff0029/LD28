using UnityEngine;
using System.Collections;

public class RespawnRock : MonoBehaviour {

    public float cooldownTime;
    public Controler controller;
    public GameObject rockPrefab;
    public Transform rockPosition;
    public Transform rockParent;
    bool canRespawn = false;

	void Start()
    {
        controller.onRockThrow += HandleRockThrow;
    }

    void Update()
    {
        if (canRespawn && Input.GetMouseButtonDown(1))
            SpawnRock();

        if (Input.GetKeyDown(KeyCode.P))
            canRespawn = true;
    }

    void SpawnRock()
    {
        canRespawn = false;
        rockPrefab.rigidbody.isKinematic = true;
        GameObject rock = (GameObject)Instantiate(rockPrefab, rockPosition.position, rockPosition.rotation);
        controller.rock = rock.rigidbody;
        rock.transform.parent = rockParent;

    }
    void HandleRockThrow()
    {
        StartCoroutine(RockCooldown());
    }


    IEnumerator RockCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canRespawn = true;
        controller.CanThrowRock = true;
    }
}
