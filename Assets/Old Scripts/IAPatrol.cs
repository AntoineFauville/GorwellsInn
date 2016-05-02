using UnityEngine;
using System.Collections;

public class IAPatrol : MonoBehaviour {

    NavMeshAgent agent;
    public int randDes;
    public float dist;
    public Transform[] destinations;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        randDes = Random.Range(0, destinations.Length);
        agent.destination = destinations[randDes].position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.tag != "Dead")
        {
            // Récupere la distance entre l'IA et sa destination actuelle.
            dist = Vector3.Distance(this.transform.position, destinations[randDes].position);

            // si la distance est inférieure à 2 alors il repart.
            if (dist < 2)
            {
                randDes = Random.Range(0, destinations.Length);
                agent.destination = destinations[randDes].position;
            }
        }
    }
}
