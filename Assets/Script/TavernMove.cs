using UnityEngine;
using System.Collections;

public class TavernMove : MonoBehaviour 
{

	public GameObject spawn;
	public GameObject cam;
	GameObject player;
	GameObject vision;

	void Start()
	{
		vision = GameObject.Find ("Main Camera");
		player = GameObject.Find ("Player");
	}

	void OnTriggerEnter(Collider detect)
	{
		if (detect.gameObject.tag == "Player") 
		{
			player.transform.position = spawn.transform.position;
			vision.transform.position = cam.transform.position;
		}
	}

}
