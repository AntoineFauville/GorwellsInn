using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossMapper : MonoBehaviour {

    List<Object> BossMaps = new List<Object>();
    int rand;

    void Awake()
    {
        BossMaps.Add(Resources.Load("SalleBoss1"));
        BossMaps.Add(Resources.Load("SalleBoss2"));
        BossMaps.Add(Resources.Load("SalleBoss3"));
    }

    void Start()
    {
        rand = Random.Range(0, BossMaps.Count);
        Instantiate(BossMaps[rand], transform.position, transform.rotation);
    }
}
