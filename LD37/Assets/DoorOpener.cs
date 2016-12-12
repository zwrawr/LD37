using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {

    Animator animator;
    public string animName;

	// Use this for initialization
	void Start () {
        animator = this.GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        // open this door
        Debug.Log(animName);

        animator.SetTrigger(animName);

    }
}
