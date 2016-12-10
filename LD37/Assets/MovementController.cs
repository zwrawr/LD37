using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {


    public Vector2 KeyBoardSensitivity;
    public Vector2 MouseSensitivity;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        doKeyboardMovement();
        doMouseMovement();

    }

    void doKeyboardMovement()
    {
        Vector3 pos = this.transform.position;

        float hoz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        pos += this.transform.right * hoz * Time.deltaTime * KeyBoardSensitivity.x;
        pos += this.transform.forward * vert * Time.deltaTime * KeyBoardSensitivity.y;


        this.transform.position = pos;
    }

    void doMouseMovement()
    {
        this.transform.Rotate(this.transform.up, Input.GetAxis("Mouse X")*Time.deltaTime*MouseSensitivity.x*100);
    }

}
