using UnityEngine;
using System.Collections;
using Pathfinding;

public class Zombie : IA {

	/* Mouvement */
	private NavMeshAgent path;
	private Personnage player;
    public Vector3 targetPosition;
	/**/

	/* Mort */
	public Animator die;
	/**/

	/* Animation */
	public Animator feet;
	public Animator body;
	/**/

	public override void Start () 
	{
		base.Start ();
        base.salleNumber();
        base.life = 2;
		path = GetComponent<NavMeshAgent> ();
		feet = this.transform.FindChild ("Zombie/Pied").GetComponent<Animator>();
		body = this.transform.FindChild ("Zombie/HautDuCorps Monstres").GetComponent<Animator>();
		player = GameObject.Find ("Player").GetComponent<Personnage> ();
		die = this.transform.Find ("Zombie").GetComponent<Animator>();
	}

	public override void Update () 
	{
		base.Update ();
		Mouvement ();
		die.SetBool("Mort", mort);

		if (mort == true) 
		{
			path.enabled = false;
		}

		if (this.gameObject.tag != "Dead") 
		{
			if (player.transform.position.z > this.gameObject.transform.position.z)
			{
				feet.SetBool("Vertical", true);
				body.SetBool("Vertical", true);
			}
			else
			{
				feet.SetBool("Vertical", false);
				body.SetBool("Vertical", false);
			}
		}
	}

	void Mouvement()
	{
		if (this.gameObject.tag != "Dead") 
		{
            /* OLD PATHFINDING SYSTEM
            // On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
			float dist = Vector3.Distance(player.transform.position, transform.position);
			// Condition afin qu'il récupére toujours la position du joueur si il est suffisamment éloigné.
			if (dist > 2 && path.enabled)
			{
				path.destination = player.transform.position;
			}
            */

            Seeker seeker = GetComponent<Seeker>();
            seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
		}
	}

    public void OnPathComplete (Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }
}
