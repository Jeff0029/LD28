using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour {

    public Level levelSelection;
    public AudioClip clickSound;

	void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        LevelState.SetLevelState = levelSelection;
    }
}
