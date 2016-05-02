using UnityEngine;
using System.Collections;

public class ParticuleSpawner : MonoBehaviour {

    public Transform chestPrefab;
    private float spawnTime = 10f;
    private Transform blood;


    void Start()
    {
        StartCoroutine(SpawnBlood());
    }

    //coroutine
    IEnumerator SpawnBlood()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            blood = chestPrefab;
            Instantiate(blood, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
