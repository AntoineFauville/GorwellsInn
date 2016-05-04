using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    List<Object> Enemy = new List<Object>();
    int rand;
    Object ennemy;

    // Call before launch of the script
    void Awake()
    {
        Enemy.Add(Resources.Load("AcidMan"));
        Enemy.Add(Resources.Load("DarkMage"));
        Enemy.Add(Resources.Load("Fantom"));
        Enemy.Add(Resources.Load("OneEye"));
        Enemy.Add(Resources.Load("Skeleton"));
        Enemy.Add(Resources.Load("Zombie"));
    }

	// Use this for initialization
	void Start ()
    {
        rand = Random.Range(0, 6);
        Instantiate(Enemy[rand], transform.position, transform.rotation); 
	}
}
