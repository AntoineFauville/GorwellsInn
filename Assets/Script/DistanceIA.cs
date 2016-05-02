using UnityEngine;
using System.Collections;

public class DistanceIA : MonoBehaviour {

    // Script permettant aux IA d'attaquer à distance avec un suivi du joueur ou non.

    public float rand = 1.5f;
    private bool shoot = true;
    public Rigidbody weapon;
    public Transform spawnRight;
    public Transform player;
    GameObject IA;

    void Start()
    {
        //rand = 1.5f/*Random.Range(1, 6)*/;
        player = GameObject.Find("Player").GetComponent<Transform>();
        IA = this.gameObject;
		StartCoroutine(WaitAndShot());
    }

	// Update is called once per frame
	void Update ()
    {
        if (shoot == false && IA.tag != "Dead" )
        {
            //rand = 1.5f /*Random.Range(1, 6)*/;
            Shot();
        }
	}

    void Shot()
    {
        Rigidbody ball;
        shoot = true;

        if (player.position.x > transform.position.x)
        {
            ball = Instantiate(weapon, spawnRight.position, spawnRight.rotation) as Rigidbody;
            //ball.AddForce(spawnRight.right * 1000);
        }

        StartCoroutine(WaitAndShot());
    }

    IEnumerator WaitAndShot()
    {
        yield return new WaitForSeconds(rand);
        shoot = false;
    }
}
