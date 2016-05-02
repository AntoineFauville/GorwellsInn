using UnityEngine;
using System.Collections;

public class IATentaclesDistance : MonoBehaviour {

    private int rand;
    private bool shooting = true;
    private bool guarding = false;
    public Rigidbody projectile;
    public Transform spawnProjectile;
    public Transform player;
    public GameObject corps;

	// Use this for initialization
	void Start ()
    {
        rand = Random.Range(2, 8);
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(WaitAndShot());
        StartCoroutine(WaitAndGuard());
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (shooting == false && corps.tag != "Dead")
        {
            rand = Random.Range(2, 8);
            Shot();
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 5 && guarding == false && corps.tag != "Dead")
        {
            ShotGuard();
        }
	}

    void Shot()
    {
        Rigidbody ball;
        shooting = true;

        ball = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation) as Rigidbody;

        StartCoroutine(WaitAndShot());
    }
    void ShotGuard()
    {
        Rigidbody ball;
        guarding = true;   

        ball = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation) as Rigidbody;

        StartCoroutine(WaitAndGuard());
    }

    IEnumerator WaitAndShot()
    {
        yield return new WaitForSeconds(rand);
        shooting = false;
    }

    IEnumerator WaitAndGuard()
    {
        yield return new WaitForSeconds(2);
        guarding = false;
    }
}
