using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour {

	private GameObject player;
	private Personnage playerInfo;
	NavMeshAgent agent;
    public bool damaging;

	void Start () {
        // on assigne le NavMeshAgent à la variable agent.
		agent = GetComponent<NavMeshAgent> ();

		player = GameObject.Find ("Player");
		playerInfo = GameObject.Find ("Player").GetComponent<Personnage> ();

        // On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
		agent.destination = player.transform.position;
	}
	
	void Update () 
	{
		if (this.gameObject.tag != "Dead") 
		{
			// On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
			float dist = Vector3.Distance(player.transform.position, transform.position);
			// Condition afin qu'il récupére toujours la position du joueur si il est suffisamment éloigné.
			if (dist > 2)
			{
				agent.destination = player.transform.position;
			}
		}
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if ( coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
        {
            //damaging = true;
            playerInfo.TakeDamage();
            StartCoroutine(StopAttack());
            //damaging = false;
        }
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
        {
            //damaging = true;
            playerInfo.TakeDamage();
            StartCoroutine(StopAttack());
            //damaging = false;
        }
    }

    /*void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
        {
            damaging = true;
            playerInfo.TakeDamage();
           //damaging = false;
        }
    }*/

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.24f);
        damaging = false;
    }
}
