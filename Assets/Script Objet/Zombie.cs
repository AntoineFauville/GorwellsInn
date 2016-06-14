using UnityEngine;
using System.Collections;
using Pathfinding;

public class Zombie : IA {

	/* Mouvement */
	private NavMeshAgent path;
	private Personnage player;

    private Seeker seeker;
    private CharacterController controller;
    public Path way;
    public float speed = 15;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
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

            seeker = GetComponent<Seeker>();
            seeker.StartPath(this.transform.position, player.transform.position);

           /* if (way == null)
            {
                return;
            }

            if (currentWaypoint >= way.vectorPath.Count)
            {
                Debug.Log("End of Path Reached");
                return;
            }
            Vector3 dir = (way.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.deltaTime;
            controller.SimpleMove(dir);

            if (Vector3.Distance (transform.position,way.vectorPath[currentWaypoint]) < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }*/
		}
	}
}
