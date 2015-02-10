using UnityEngine;
using System.Collections;

public class JumpCheck : MonoBehaviour {

    public Controler controler;

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SoundLayer"))
            controler.CanJump = true;
        else
            controler.CanWalk = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SoundLayer"))
            controler.CanJump = false;
    }
}
