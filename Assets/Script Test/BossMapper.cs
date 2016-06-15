using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossMapper : MonoBehaviour {

    List<Object> BossMaps = new List<Object>();
    int rand;
    GameObject bossMap;
    AstarPath scanner;

    void Awake()
    {
        scanner = GameObject.Find("A*").GetComponent<AstarPath>();
        BossMaps.Add(Resources.Load("SalleBoss1"));
        BossMaps.Add(Resources.Load("SalleBoss2"));
        BossMaps.Add(Resources.Load("SalleBoss3"));
    }

    void Start()
    {
        rand = Random.Range(0, BossMaps.Count);
        bossMap = Instantiate(BossMaps[rand], transform.position, transform.rotation) as GameObject;
        bossMap.transform.SetParent(this.transform);
        scanner.Scan();
    }
}
