using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossSpawner : MonoBehaviour {

    List<Object> Boss = new List<Object>();
    int rand;
    GameObject ennemy;

    void Awake()
    {
        Boss.Add(Resources.Load("Boss Oeil"));
        Boss.Add(Resources.Load("Boss Cthulhu"));
        Boss.Add(Resources.Load("Owl Master"));
    }

    void Start ()
    {
        rand = Random.Range(0, Boss.Count);
        ennemy = Instantiate(Boss[rand], this.transform.position, this.transform.rotation) as GameObject;
        ennemy.transform.SetParent(this.transform);
    }
}
