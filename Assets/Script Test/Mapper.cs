using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mapper : MonoBehaviour {

    List<Object> Maps = new List<Object>();
    List<Object> BossMaps = new List<Object>();
    int rand;
    GameObject map;
    DataBase nbreSalle;
    AstarPath scanner;

    public Transform[] mapPoints;
    public Transform[] camPoints;

    void Awake()
    {
        scanner = GameObject.Find("A*").GetComponent<AstarPath>();
        Maps.Add(Resources.Load("Salle 1"));
        Maps.Add(Resources.Load("Salle 2"));
        Maps.Add(Resources.Load("Salle 3"));
        //Maps.Add(Resources.Load("Salle 4"));
        Maps.Add(Resources.Load("Salle 5"));
        Maps.Add(Resources.Load("Salle 6"));
        Maps.Add(Resources.Load("Salle 7"));
        Maps.Add(Resources.Load("Salle 8"));
        Maps.Add(Resources.Load("Salle 9"));
        Maps.Add(Resources.Load("Salle 10"));
        Maps.Add(Resources.Load("Salle 11"));
        Maps.Add(Resources.Load("Salle 12"));
        Maps.Add(Resources.Load("Salle 13"));
        //Maps.Add(Resources.Load("Salle 14"));
        Maps.Add(Resources.Load("Salle 15"));
        BossMaps.Add(Resources.Load("SalleBoss1"));
        BossMaps.Add(Resources.Load("SalleBoss2"));
        BossMaps.Add(Resources.Load("SalleBoss3"));
    }

    void Start()
    {
        for (int i = 0; i < mapPoints.Length; i++)
        {
            if (i == 3 || i == 7 || i == 11)
            {
                rand = Random.Range(0, BossMaps.Count);
                map = Instantiate(BossMaps[rand], mapPoints[i].position, mapPoints[i].rotation) as GameObject;
                map.transform.SetParent(mapPoints[i]);
                map.name = "Salle";
                nbreSalle = map.GetComponent<DataBase>();
                nbreSalle.ChangeNumberRoom(i);
            }
            else
            {
                rand = Random.Range(0, Maps.Count);
                map = Instantiate(Maps[rand], mapPoints[i].position, mapPoints[i].rotation) as GameObject;
                map.transform.SetParent(mapPoints[i]);
                map.name = "Salle";
                nbreSalle = map.GetComponent<DataBase>();
                nbreSalle.ChangeNumberRoom(i);
            }
        }
        scanner.Scan();
    }
}
