using UnityEngine;
using System.Collections;

public class Fantom : IA {

	/* Mouvement */
	private NavMeshAgent path;
	private float dist;
	private int randDes;
	//public Transform[] destinations;
	private DataBase data;
	private string room;
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
		room = "Salle " + salle;
		data = GameObject.Find (room).GetComponent<DataBase>();
		path = GetComponent<NavMeshAgent> ();
		randDes = Random.Range (0, data.salleAléa.Length);
		path.destination = data.salleAléa [randDes].position;
		die = this.transform.Find ("Fantom").GetComponent<Animator>();
		StartCoroutine (SpawnCloud ());
	}

	public override void Update () 
	{
		base.Update ();
		Movement ();
		die.SetBool("Mort", mort);

		if (mort == true) 
		{
			path.enabled = false;
			spawning = false;
		}
	}

	void Movement()
	{
		randDes = Random.Range (0, data.salleAléa.Length);

		if (this.gameObject.tag != "Dead") 
		{
			dist = Vector3.Distance (this.transform.position, data.salleAléa [randDes].position);

			if (dist < 2) 
			{
				randDes = Random.Range (0, data.salleAléa.Length);
				path.destination = data.salleAléa [randDes].position;
			}
		}
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
