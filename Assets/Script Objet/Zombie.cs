using UnityEngine;
using System.Collections;
using Pathfinding;

public class Zombie : IA {

	/* Mouvement */
	private Personnage player;
    private AILerpPursuit follow;
    private Seeker seeker;
    private Path way;
    private float speed = 6;
    private float nextWaypointDistance = 3;
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
		feet = this.transform.FindChild ("Zombie/Pied").GetComponent<Animator>();
		body = this.transform.FindChild ("Zombie/HautDuCorps Monstres").GetComponent<Animator>();
		player = GameObject.Find ("Player").GetComponent<Personnage> ();
		die = this.transform.Find ("Zombie").GetComponent<Animator>();
        follow = GetComponent<AILerpPursuit>();
    }

	public override void Update () 
	{
		base.Update ();
		//Mouvement ();
		die.SetBool("Mort", mort);

		if (mort == true) 
		{
            follow.OnDisable();
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

            /*if (AstarPath.active == null) return;

            var p = ABPath.Construct(transform.position, player.transform.position, OnPathComplete);

            AstarPath.StartPath(p);*/

            // Mouvement A*
            if (way == null)
            {
                return;
            }

            if (currentWaypoint >= way.vectorPath.Count)
            {
                Debug.Log("End of Path Reached");
                currentWaypoint = 0;
                return;
            }

            Vector3 dir = (way.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.deltaTime;
            transform.Translate(dir);
            print("Moving to next point");

            if (Vector3.Distance(transform.position, way.vectorPath[currentWaypoint]) < nextWaypointDistance)
            {
                print("Next Waypoint");
                currentWaypoint++;
                return;
            }

            if (Vector3.Distance(transform.position, player.transform.position) > 2)
            {
                seeker.StartPath(this.transform.position, player.transform.position, OnPathComplete);
            }

        }
	}

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            way = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }
}
