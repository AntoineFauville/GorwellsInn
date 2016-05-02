using UnityEngine;
using System.Collections;

public class FireBallBehavior : MonoBehaviour {

    public Transform player;
    Rigidbody clone; 

	// Use this for initialization
	void Start ()
    {
        clone = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>(); 

        clone.velocity = (player.transform.position - transform.position).normalized * 12;
        // Cette ligne permet de cibler vers le joueur.
	}
}
