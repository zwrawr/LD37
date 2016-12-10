using UnityEngine;
using System.Collections;

public class WeponManager : MonoBehaviour {

    public float cooldown = 0.75f;
    float cooldown_left = 0f;

    public float damagepershot = 10f;

    ParticleSystem ps;
    AudioSource aus;

	// Use this for initialization
	void Start () {
        ps = this.transform.GetComponentInChildren<ParticleSystem>();
        aus = this.transform.GetComponentInChildren<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1") && cooldown_left < 0f)
        {
            fire();
        }

        cooldown_left -= Time.deltaTime;
	}

    void fire()
    {
        ps.Play();
        aus.Play();

        cooldown_left = cooldown;

        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 25f))
        {

            Debug.Log(hitInfo.transform.name);

            Health health = hitInfo.transform.GetComponent<Health>();
            if (health != null)
            {
                health.takeDamage(damagepershot);
            }
        }
    }
}
