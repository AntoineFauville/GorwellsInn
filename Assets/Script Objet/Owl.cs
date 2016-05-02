using UnityEngine;
using System.Collections;

public class Owl : Boss {

	/* Mouvement */
	private NavMeshAgent path;
	private Personnage player;
	/**/

	/* Mort */
	public Animator touched;
	public GameObject mort;
	/**/

	public override void Start () 
	{
		base.Start();

		path = GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("Player").GetComponent<Personnage> ();
	}

	public override void Update () 
	{
		base.Update();

		if (bossLife <= 0 /*&& dead == false*/)
		{
			//door.Counter ();
			path.enabled = false;
			touched.Stop();
			mort.SetActive (true);
		}

		if (this.gameObject.tag != "Dead") 
		{
			touched.SetBool ("Touched", hit);
			Mouvement ();
		}
	}

	public void  Mouvement()
	{
		// On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
		float dist = Vector3.Distance(player.transform.position, transform.position);
		// Condition afin qu'il récupére toujours la position du joueur si il est suffisamment éloigné.
		if (dist > 2)
		{
			path.destination = player.transform.position;
		}
	}
}
