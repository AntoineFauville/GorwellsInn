using UnityEngine;
using System.Collections;

public class IARanged : MonoBehaviour {

    private int rand;
    private bool shoot = true;
    private int nbreShoot;
    public Transform[] spawns;
    public Rigidbody weapon;
    public Transform player;
    GameObject IA;

    // Use this for initialization
    void Start ()
    {
        rand = 1/*Random.Range(1, 6)*/;
        nbreShoot = 1/*Random.Range(0, 2)*/;
        player = GameObject.Find("Player").GetComponent<Transform>();
        IA = this.gameObject;
        StartCoroutine(WaitAndShot());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shoot == false && IA.tag != "Dead")
        {
            rand = 1/*Random.Range(1, 6)*/;
            nbreShoot = 1/*Random.Range(0, 2)*/;
            Shot();
        }
    }

    void Shot()
    {
        Rigidbody ball;
        shoot = true;

        if (nbreShoot == 0)
        {
            ball = Instantiate(weapon, spawns[0].position, spawns[0].rotation) as Rigidbody;
        }
        else if (nbreShoot == 1)
        {
            for (int i = 1; i < 1; i++)
            {
                ball = Instantiate(weapon, spawns[i].position, spawns[i].rotation) as Rigidbody;
                // Instantie un clone du projectile.
            }
        }

        StartCoroutine(WaitAndShot());
    }

    IEnumerator WaitAndShot()
    {
        yield return new WaitForSeconds(1.0f);
        shoot = false;
    }
}
