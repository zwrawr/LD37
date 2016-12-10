using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    float score;


    public Text scoreText;
    public float scoreTextUpdateRate = 0.5f;
    float lastupdate = 0;

	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
        lastupdate += Time.deltaTime;

        if (lastupdate > scoreTextUpdateRate)
        {
            lastupdate = 0;
            scoreText.text = "Score : " + score;
        }
    }

    public void addScore(float score)
    {
        this.score += score;
    }
}
