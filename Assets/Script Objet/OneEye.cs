using UnityEngine;
using System.Collections;

public class OneEye : IA {

    /* Mouvement */
    private AILerpPatrol patrol;
    private Transform parentA;
    private Transform parentB;
    public DataBase pathFinding;
	private int i = 0;
	public string room;
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
        base.salleNumber();
        room = "Salle " + base.salle;
        parentA = this.transform.parent; // IA
        parentB = parentA.parent; //EnnemiTransform
        parentA = parentB.parent; // EnnemiManager
        parentB = parentA.parent; // Salle
        pathFinding = parentB.GetComponent<DataBase>();
        player = GameObject.Find ("Player").GetComponent<Personnage> ();
		feet = this.transform.FindChild ("OneEye/Pied").GetComponent<Animator>();
		body = this.transform.FindChild ("OneEye/HautDuCorps Monstres").GetComponent<Animator>();
		die = this.transform.Find ("OneEye").GetComponent<Animator>();
        patrol = GetComponent<AILerpPatrol>();
	}

	public override void Update () 
	{
		base.Update ();
		//Mouvement ();
		die.SetBool("Mort", mort);

		if (mort == true) 
		{
            patrol.OnDisable();
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
        /*if (this.gameObject.tag != "Dead")
		{
			float dist = Vector3.Distance(pathFinding.salle[i].transform.position, this.gameObject.transform.position);

			if (dist < 2 && path.enabled == true)
			{
				i++;
				if (i < pathFinding.salle.Length)
				{
					path.destination = pathFinding.salle[i].transform.position;          
				}
			}

			if (i == pathFinding.salle.Length && path.enabled == true)
			{
				i = 0;
				path.destination = pathFinding.salle[i].transform.position;
			}
		}*/
    }
}
