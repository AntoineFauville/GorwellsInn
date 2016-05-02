using UnityEngine;
using System.Collections;

public class ABCDDeplacement : MonoBehaviour {

    // Script permettant à un ennemi de faire des rondes.

	public Transform[] targets;
	NavMeshAgent agent;
	private int i = 0;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = targets [i].transform.position;
	}
	
	void Update () {
		float dist = Vector3.Distance (targets [i].transform.position, transform.position);

		if(dist < 2){
			i++;
			if(i < targets.Length)	{
				agent.destination = targets [i].transform.position;
			}
		}

		if (i == targets.Length)	{
			i = 0;
			agent.destination = targets [i].transform.position;
		}
	}
}
