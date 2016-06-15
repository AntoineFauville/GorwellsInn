using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mapper : MonoBehaviour {

    List<Object> Maps = new List<Object>();
    int rand;
    GameObject map;

    void Awake()
    {
        Maps.Add(Resources.Load("Salle 1"));
        Maps.Add(Resources.Load("Salle 2"));
        Maps.Add(Resources.Load("Salle 3"));
        Maps.Add(Resources.Load("Salle 4"));
        Maps.Add(Resources.Load("Salle 5"));
        Maps.Add(Resources.Load("Salle 6"));
        Maps.Add(Resources.Load("Salle 7"));
        Maps.Add(Resources.Load("Salle 8"));
        Maps.Add(Resources.Load("Salle 9"));
        Maps.Add(Resources.Load("Salle 10"));
        Maps.Add(Resources.Load("Salle 11"));
        Maps.Add(Resources.Load("Salle 12"));
        Maps.Add(Resources.Load("Salle 13"));
        Maps.Add(Resources.Load("Salle 14"));
        Maps.Add(Resources.Load("Salle 15"));
    }

    void Start()
    {
        rand = Random.Range(0, Maps.Count);
        map = Instantiate(Maps[rand], transform.position, transform.rotation) as GameObject;
        map.transform.SetParent(this.transform);
    }
}
