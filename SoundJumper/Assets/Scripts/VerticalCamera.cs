using UnityEngine;
using System.Collections;

public class VerticalCamera : MonoBehaviour {

    public float rotationSpeed;
    public float maxUpAngle;
    public float minUpAngle;
    private float oldMousePos;
	// Update is called once per frame

	void Update () 
    {
        // Rotate Up
        if (Input.GetAxis("Mouse Y") > 0 && transform.localRotation.x > maxUpAngle)
            transform.Rotate(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0, Space.Self);
        // Rotate Down
        if (Input.GetAxis("Mouse Y") < 0 && transform.localRotation.x < minUpAngle)
        transform.Rotate(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0, Space.Self);
	}
}
