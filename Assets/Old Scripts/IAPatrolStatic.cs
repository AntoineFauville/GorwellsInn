using UnityEngine;
using System.Collections;

public class IAPatrolStatic : MonoBehaviour {

    NavMeshAgent agent;
    public Transform[] destinations;
    private int i = 0;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destinations[i].transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(destinations[i].transform.position, transform.position);

        if (dist < 2)
        {
            i++;
            if (i < destinations.Length)
            {
                agent.destination = destinations[i].transform.position;          
            }
        }

        if (i == destinations.Length)
        {
            i = 0;
            agent.destination = destinations[i].transform.position;
        }
    }
}
