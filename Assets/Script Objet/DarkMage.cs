using UnityEngine;
using System.Collections;

public class DarkMage : IA {

	/* Attaque */
	private float rand = 1.5f;
	private bool shoot = true;
	public Rigidbody weapon;
	public Transform spawn;
	private Transform player;
	Rigidbody ball;
	/**/

	/* Mort */
	public Animator die;
	/**/

	public override void Start () 
	{
		base.Start ();
		player = GameObject.Find("Player").GetComponent<Transform>();
		die = this.transform.Find ("DarkMage").GetComponent<Animator>();
		StartCoroutine (WaitAndShot ());
	}

	public override void Update () 
	{
		base.Update ();
		if (shoot == false && this.gameObject.tag != "Dead") 
		{
			Attaque ();
		}

		die.SetBool("Mort", mort);
	}

	public void Attaque()
	{
		shoot = true;
		Instantiate(weapon, spawn.position, spawn.rotation);
		StartCoroutine(WaitAndShot());
	}

	IEnumerator WaitAndShot()
	{
		yield return new WaitForSeconds(rand);
		shoot = false;
	}
}
