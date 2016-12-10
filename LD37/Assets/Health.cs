using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float startHealth;

    public float health;

    public bool giveDamageAsScore;
    public bool giveStartHealthAsScoreOnDeath;

    ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        scoreManager = GameObject.Find("_SCRIPTS_").GetComponent<ScoreManager>();

        health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}


    public int takeDamage(float damage)
    {
        if (this.enabled == false)
        {
            return -1;
        }


        this.health -= damage;

        if (giveDamageAsScore)
        {
            scoreManager.addScore(damage);
        }

        if (this.health <= 0)
        {
            // were dead 

            if (giveStartHealthAsScoreOnDeath)
            {
                scoreManager.addScore(startHealth);
            }

            this.enabled=false;

            return 1;
        }
        else
        {
            return 0;
        }
    }
}
