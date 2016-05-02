using UnityEngine;
using System.Collections;

public class Oeil : Boss {

	/* Mouvement */
	private NavMeshAgent path;
	private int randDes;
	private float dist;
	public Transform[] destinations;
	/**/

	/* Mort */
	public Animator touched;
	public GameObject mort;
	/**/

	/* Attaque */
	public Rigidbody projectile;
	Rigidbody clone;
	public Transform[] spawn;
	public Transform[] target;
	private bool shot = true;
	private int randShoot;
	private int randTime;
	private bool twoWays = false;
	private bool fourWays = false;
	private bool eightWays = false;
	/**/

	/* Laser */
	public Animator LaserOn;
	private bool laser1;
	private bool laser2;
	private bool laser3;
	private bool laser4;
	private bool laserPrepa;
	private bool shoot = false;
	private int randLaser;
	/**/

	public override void Start () 
	{
		base.Start();

		path = GetComponent<NavMeshAgent> ();
		StartCoroutine (WaitAndShot ());
		StartCoroutine(Lazzer());
	}

	public override void Update () 
	{
		base.Update();

		if (bossLife <= 0 /*&& dead == false*/)
		{
			//door.Counter ();
			path.enabled = false;
			touched.Stop();
			LaserOn.Stop ();
			mort.SetActive (true);
		}

		if (this.gameObject.tag != "Dead") 
		{
			touched.SetBool ("Touched", hit);
			Mouvement ();
			Projectiles ();
			Laser ();	
		}

        if (this.gameObject.tag == "Dead")
        {
            //LaserOn.Stop();
            LaserOn.gameObject.SetActive(false);
        }
    }

	void Mouvement()
	{
		randDes = Random.Range(0, destinations.Length);

		if (this.gameObject.tag != "Dead")
		{
			// Récupere la distance entre l'IA et sa destination actuelle.
			dist = Vector3.Distance(this.transform.position, destinations[randDes].position);

			// si la distance est inférieure à 2 alors il repart.
			if (dist < 2)
			{
				randDes = Random.Range(0, destinations.Length);
				path.destination = destinations[randDes].position;
			}
		}
	}

	void Laser()
	{
		if ( this.gameObject.tag != "Dead")
		{
			LaserOn.SetBool("LazzerOn", laserPrepa);
			LaserOn.SetBool("Lazer1", laser1);
			LaserOn.SetBool("Lazer2", laser2);
			LaserOn.SetBool("Lazer3", laser3);
			LaserOn.SetBool("Lazer4", laser4);
		}

		if (shoot == true && this.gameObject.tag != "Dead")
		{
			shoot = false;
			randLaser = Random.Range(0,4);

			if (randLaser == 0)
			{
				laser1 = true;
				laser2 = false;
				laser3 = false;
				laser4 = false;
			}
			else if (randLaser == 1)
			{
				laser1 = false;
				laser2 = true;
				laser3 = false;
				laser4 = false;
			}
			else if (randLaser == 2)
			{
				laser1 = false;
				laser2 = false;
				laser3 = true;
				laser4 = false;
			}
			else if (randLaser == 3)
			{
				laser1 = false;
				laser2 = false;
				laser3 = false;
				laser4 = true;
			}

			StartCoroutine(PrepaLazer());
			StartCoroutine(Lazzer());
		}

		if (this.gameObject.tag =="Dead")
		{
			//LaserOn.Stop();
			LaserOn.gameObject.SetActive(false);
		}
	}

	void Projectiles()
	{
		if (shot == false) 
		{
			if (twoWays == true)
			{
				for (int i = 0; i < 2; i++)
				{
					clone = Instantiate(projectile, spawn[i].position, spawn[i].rotation) as Rigidbody;
					// Instantie un clone du projectile.
					clone.velocity = (target[i].transform.position - transform.position).normalized * 12;
					// Envoie le clone dans une direction fixe.
					shot = true;
				}
			}
			else if (fourWays == true)
			{
				for (int i = 0; i < 4; i++)
				{
					clone = Instantiate(projectile, spawn[i].position, spawn[i].rotation) as Rigidbody;
					// Instantie un clone du projectile.
					clone.velocity = (target[i].transform.position - transform.position).normalized * 12;
					// Envoie le clone dans une direction fixe.
					shot = true;
				}
			}
			else if (eightWays == true)
			{
				for (int i = 0; i < 8; i++)
				{
					clone = Instantiate(projectile, spawn[i].position, spawn[i].rotation) as Rigidbody;
					// Instantie un clone du projectile.
					clone.velocity = (target[i].transform.position - transform.position).normalized * 12;
					// Envoie le clone dans une direction fixe.
					shot = true;
				}
			}

			StartCoroutine(WaitAndShot());
		}
	}

	IEnumerator WaitAndShot()
	{
		randShoot = Random.Range (0, 3);

		if (randShoot == 0)
		{
			twoWays = true;
			fourWays = false;
			eightWays = false;
		}
		else if (randShoot == 1)
		{
			twoWays = false;
			fourWays = true;
			eightWays = false;
		}
		else if (randShoot == 2)
		{
			twoWays = false;
			fourWays = false;
			eightWays = true;
		}

		randTime = Random.Range(1, 4);

		yield return new WaitForSeconds(randTime);
		shot = false;
	}

	IEnumerator Lazzer()
	{
		yield return new WaitForSeconds(4);
		shoot = true;
	}

	IEnumerator PrepaLazer()
	{
		laserPrepa = true;
		yield return new WaitForSeconds(3);
		laserPrepa = false;
	}
}
