using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;

    public GameObject FirstChild;
    public float timeBetweenSpawns = 20f;
    float lastSpawn = 100f;

    List<Transform> pathPoints;

	// Use this for initialization
	void Start () {
        pathPoints = new List<Transform>();

        Transform current = FirstChild.transform;
        string name = FirstChild.name;
        int i = 0;

        while ( current != null)
        {
            pathPoints.Add(current.transform);

            i++;

            current = this.transform.FindChild(name + "_" + i);
        }

        Debug.Log("Number of pathPoints : " + i);

	}
	
	// Update is called once per frame
	void Update () {
        lastSpawn += Time.deltaTime;
        if (lastSpawn > timeBetweenSpawns)
        {
            doSpawn();
            lastSpawn = 0;
        }
    }

    void doSpawn()
    {
        GameObject tmp = (GameObject)Instantiate(Enemy, this.transform.position, this.transform.rotation, this.transform);
        Debug.Log("Spawned Enemy");
        enemyAI ai = tmp.GetComponent<enemyAI>();
        ai.pathPoints = this.pathPoints.ToArray();
    }
}
