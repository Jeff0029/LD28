using UnityEngine;
using System.Collections;

public class SwitchMenuState : MonoBehaviour {

    public GameObject[] buttons;
    private bool isSelectSelected = false;

    public Texture selectTexture;
    public Texture backTexture;

    public AudioClip clickSound;

	void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        if (isSelectSelected)
        {
            isSelectSelected = false;
            renderer.material.mainTexture = selectTexture;
            toggleVisibilityButton(false);
        }
        else
        {
            isSelectSelected = true;
            renderer.material.mainTexture = backTexture;
            toggleVisibilityButton(true);
        }
    }

    void toggleVisibilityButton(bool isVisible)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(isVisible);
        }
    }
}
