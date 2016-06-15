using UnityEngine;
using System.Collections;

public class Skeleton : IA {

	/* Mouvement */
	private Personnage player;
    private AILerpPursuit follow;
    /**/

    /* Charge */
    Rigidbody corps;
	private int randTime;
	private bool charge = true;
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
		player = GameObject.Find ("Player").GetComponent<Personnage> ();
		corps = GetComponent<Rigidbody> ();
		feet = this.transform.FindChild ("Skeleton/Pied").GetComponent<Animator>();
		body = this.transform.FindChild ("Skeleton/HautDuCorps Monstres").GetComponent<Animator>();
		die = this.transform.Find ("Skeleton").GetComponent<Animator>();
        follow = GetComponent<AILerpPursuit>();
        StartCoroutine (WaitAndCharge ());
	}

	public override void Update () 
	{
		base.Update ();
		//Mouvement ();
		Charge ();
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
        /*
		if (this.gameObject.tag != "Dead") 
		{
			// On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
			float dist = Vector3.Distance(player.transform.position, transform.position);
			// Condition afin qu'il récupére toujours la position du joueur si il est suffisamment éloigné.
			if (dist > 2)
			{
				path.destination = player.transform.position;
			}
		}
        */
	}

	void Charge()
	{
		if (charge == false && corps.tag != "Dead")
		{
			StartCoroutine(WaitAndCharge());
            corps.velocity = (player.transform.position - transform.position).normalized * 20;
			// Cette ligne permet de cibler vers le joueur.
			charge = true;	
		}	
	}

	IEnumerator WaitAndCharge()
	{
		randTime = Random.Range(3,7);

		yield return new WaitForSeconds(randTime);
		charge = false;
	}
}
