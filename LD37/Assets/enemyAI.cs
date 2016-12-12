using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {

    public Transform[] pathPoints;
    public int current = 0;
    public float mindist = 0.1f;
    public float angluarSpeed = 0.2f;
    public float maxStepSize = 0.25f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (current < pathPoints.Length)
        {
            // heading towards the room
            if (isAtPoint())
            {
                current++;
            }
            else
            {
                moveToPoint();
            }
        }
        else
        {
            //where in the room now, go to attack AI

            Vector3 oldPos = this.transform.position;
            Vector3 newPos = Vector3.MoveTowards(this.transform.position, Camera.main.transform.parent.position, maxStepSize);
            // move forward
            this.transform.position = newPos;
        }
	}

    bool isAtPoint()
    {
        if (Vector3.Distance(this.transform.position, pathPoints[current].position) < mindist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void moveToPoint()
    {

        Vector3 oldPos = this.transform.position;
        Vector3 newPos = Vector3.MoveTowards(this.transform.position, pathPoints[current].position, maxStepSize);
        // move forward
        this.transform.position = newPos;


        //Vector3 deltaPos = newPos - oldPos;

        // change angle
        //float deltaAngle = Vector3.Angle(pathPoints[current].position, this.transform.position);

        //this.transform.Rotate(Vector3.up, -deltaAngle * Time.deltaTime * angluarSpeed);
        if (current > 0)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, pathPoints[current-1].rotation, Time.deltaTime * angluarSpeed);
        }
    }
}
