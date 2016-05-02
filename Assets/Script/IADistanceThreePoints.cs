using UnityEngine;
using System.Collections;

public class IADistanceThreePoints : MonoBehaviour {

    public Rigidbody projectile;
    Rigidbody clone;
    public Transform[] spawns;
    public Transform[] targets;
    private bool shot = true;
    private int randTime;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(WaitAndShot());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shot == false && gameObject.tag != "Dead")
        {
            StartCoroutine(WaitAndShot());
			Attack();
        }
    }

    public void Attack()
    {
        for (int i = 0; i < 3; i++)
        {
            clone = Instantiate(projectile, spawns[i].position, spawns[i].rotation) as Rigidbody;
            // Instantie un clone du projectile.
            clone.velocity = (targets[i].transform.position - transform.position).normalized * 12;
            // Envoie le clone dans une direction fixe.
            shot = true;
        }
    }

    IEnumerator WaitAndShot()
    {
        randTime = Random.Range(3,7);

        yield return new WaitForSeconds(randTime);
        shot = false;
    }
}
