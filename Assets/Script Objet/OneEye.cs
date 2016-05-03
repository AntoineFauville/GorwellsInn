using UnityEngine;
using System.Collections;

public class OneEye : IA {

	/* Mouvement */
	private NavMeshAgent path;
	//private Transform[] destinations;
	private DataBase data;
	private int i = 0;
	private string room;
	/**/

	/* Mort */
	public Animator die;
	/**/

	/* Animation */
	private Personnage player;
	public Animator feet;
	public Animator body;
	/**/

	public override void Start () 
	{
		base.Start ();
		room = "Salle " + salle;
		data = GameObject.Find (room).GetComponent<DataBase>();
		path = GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("Player").GetComponent<Personnage> ();
		feet = this.transform.FindChild ("OneEye/Pied").GetComponent<Animator>();
		body = this.transform.FindChild ("OneEye/HautDuCorps Monstres").GetComponent<Animator>();
		path.destination = data.salle[i].transform.position;
		die = this.transform.Find ("OneEye").GetComponent<Animator>();
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
			float dist = Vector3.Distance(data.salle[i].transform.position, this.gameObject.transform.position);

			if (dist < 2 && path.enabled == true)
			{
				i++;
				if (i < data.salle.Length)
				{
					path.destination = data.salle[i].transform.position;          
				}
			}

			if (i == data.salle.Length && path.enabled == true)
			{
				i = 0;
				path.destination = data.salle[i].transform.position;
			}
		}
	}
}
