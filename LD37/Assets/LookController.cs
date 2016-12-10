using UnityEngine;
using System.Collections;

public class LookController : MonoBehaviour {

    MovementController mc;
    public bool inverted = true;
    public float min;
    public float max;

	// Use this for initialization
	void Start () {
        mc = this.transform.GetComponentInParent<MovementController>();
	}
	
	// Update is called once per frame
	void Update () {
        doMouseLook();
    }

    void doMouseLook()
    {
        Vector3 rot = this.transform.localRotation.eulerAngles;
        if (inverted)
        {
            rot.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * mc.MouseSensitivity.y * 100;
        }
        else
        {
            rot.x += Input.GetAxis("Mouse Y") * Time.deltaTime * mc.MouseSensitivity.y * 100;
        }

        if (rot.x < 180)
        {
            rot.x = Mathf.Min(rot.x, max);
        }
        else
        {
            rot.x = Mathf.Max(rot.x, 360f + min);
        }

        this.transform.localRotation = Quaternion.Euler( rot.x ,rot.y, rot.z);
    }
}
