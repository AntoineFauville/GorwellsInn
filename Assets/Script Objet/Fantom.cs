using UnityEngine;
using System.Collections;

public class Fantom : IA {

    /* Mouvement */
    private AILerpPatrolFantom patrol;
	private float dist;
	private int randDes;
	//public Transform[] destinations;
	private DataBase pathFinding;
	public string room;
	/**/

	/* Nuage */
	public Transform cloudPrefab;
	private float spawnTime = 1f;
	private int randCloud;
	public Transform spawn;
	private bool spawning = true;
	/**/

	/* Mort */
	public Animator die;
	/**/

	public override void Start () 
	{
		base.Start ();
        base.salleNumber();
        room = "Salle " + base.salle;
        pathFinding = GameObject.Find (room).GetComponent<DataBase>();
		randDes = Random.Range (0, pathFinding.salleAléa.Length);
		die = this.transform.Find ("Fantom").GetComponent<Animator>();
        patrol = GetComponent<AILerpPatrolFantom>();
		StartCoroutine (SpawnCloud ());
	}

	public override void Update () 
	{
		base.Update ();
		//Movement ();
		die.SetBool("Mort", mort);

		if (mort == true) 
		{
            patrol.OnDisable();
			spawning = false;
		}
	}

	void Movement()
	{
		/*randDes = Random.Range (0, pathFinding.salleAléa.Length);

		if (this.gameObject.tag != "Dead") 
		{
			dist = Vector3.Distance (this.transform.position, pathFinding.salleAléa [randDes].position);

			if (dist < 2 && path.enabled) 
			{
				randDes = Random.Range (0, pathFinding.salleAléa.Length);
				path.destination = pathFinding.salleAléa [randDes].position;
			}
		}*/
	}

	IEnumerator SpawnCloud()
	{
		while (spawning = true && this.gameObject.tag != "Dead") 
		{
				yield return new WaitForSeconds (spawnTime);
				Instantiate (cloudPrefab, spawn.position, spawn.rotation);
		}
	}
}
