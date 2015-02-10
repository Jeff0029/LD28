using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    public Level nextLevel;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelState.SetLevelState = nextLevel;
        }
    }
}
