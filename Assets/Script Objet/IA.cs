﻿using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	/* Vie */
	protected int life = 1;
	/**/

	/* Mort */
	private bool damagable = true;
	protected bool mort = false;
	private Personnage joueur;
	private Guerrier guerrier;
	/**/

	/* Door */
	private string area;
	public int salle;
	public ChangeMap count;
	/**/


	public IA()
	{
		//life = 1;
	}

	public virtual void Start () 
	{
		joueur = GameObject.Find("Player").GetComponent<Personnage>();
		guerrier = joueur.transform.Find ("SpriteDuJoueur/Guerrier").GetComponent<Guerrier>();
		area = "AreaChanging" + salle;
		count = GameObject.Find (area).GetComponent<ChangeMap> ();
	}

	public virtual void Update () 
	{
		if (life <= 0.1 && mort != true) 
		{
			mort = true;
			this.gameObject.tag = "Dead";
			count.Counter ();
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if ( coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
		{
			joueur.TakeDamage();
		}
	}

	void OnCollisionStay(Collision coll)
	{
		if (coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
		{
			joueur.TakeDamage();
		}
	}

	private void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Weapon" && this.tag != "Dead" && damagable == true) 
		{
			life--;
			damagable = false;
			if (guerrier.gameObject.activeSelf == true) 
			{
				guerrier.LifeStealing (); // Active le vol de vie du Guerrier.	
			}
			StartCoroutine (InvicibleFrame ());
		}	
	}

	IEnumerator InvicibleFrame()
	{
		// Coroutine empechant l' I.A d'être touché plusieurs fois d'affilé en moins de 0.6 secondes.
		yield return new WaitForSeconds (0.6f);
		damagable = true;
	}
}