using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

    public SeekPlayer AI;

    void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player")
            AI.Target = other.transform;
    }
}
