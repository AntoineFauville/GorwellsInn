using UnityEngine;
using System.Collections;

public class BloodSpawner : MonoBehaviour {

    // Script permettant aux IA de laisser des traces de sang pour donner un effet plus visuel.

    public Transform[] BloodPrefab;
    private float spawnTime = 1f;
    private int rand;
    public Transform SpawnPlace;
    private Transform blood;
    public bool spawning;
	
	void Start ()
    {
        spawning = true;
        StartCoroutine(SpawnBlood());
    }

    void Update()
    {
        rand = Random.Range(0, BloodPrefab.Length);
    }

    //coroutine
    IEnumerator SpawnBlood()
    {
        while(spawning == true)
        {
            yield return new WaitForSeconds(spawnTime);
            blood = BloodPrefab[rand];
            Instantiate(blood, SpawnPlace.position, SpawnPlace.rotation);
        }
    }
}
