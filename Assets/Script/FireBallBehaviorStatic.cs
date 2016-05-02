using UnityEngine;
using System.Collections;

public class FireBallBehaviorStatic : MonoBehaviour {

    public Rigidbody projectile;
    Rigidbody clone;
    public Transform[] spawns;
    public Transform[] targets;
    private bool shot = true;
    private int randShoot;
    private int randTime;
    private bool twoWays;
    private bool fourWays;
    private bool eightWays;

    void Start()
    {
        StartCoroutine(WaitAndShot());
        twoWays = false;
        fourWays = false;
        eightWays = false;
    }

    void Update()
    {
        if (shot == false)
        {
            Attack();
            StartCoroutine(WaitAndShot());
        }
        
    }

    public void Attack()
    {
        if (twoWays == true)
        {
            for (int i = 0; i < 2; i++)
            {
                clone = Instantiate(projectile, spawns[i].position, spawns[i].rotation) as Rigidbody;
                // Instantie un clone du projectile.
                clone.velocity = (targets[i].transform.position - transform.position).normalized * 12;
                // Envoie le clone dans une direction fixe.
                shot = true;
            }
        }
        else if (fourWays == true)
        {
            for (int i = 0; i < 4; i++)
            {
                clone = Instantiate(projectile, spawns[i].position, spawns[i].rotation) as Rigidbody;
                // Instantie un clone du projectile.
                clone.velocity = (targets[i].transform.position - transform.position).normalized * 12;
                // Envoie le clone dans une direction fixe.
                shot = true;
            }
        }
        else if (eightWays == true)
        {
            for (int i = 0; i < 8; i++)
            {
                clone = Instantiate(projectile, spawns[i].position, spawns[i].rotation) as Rigidbody;
                // Instantie un clone du projectile.
                clone.velocity = (targets[i].transform.position - transform.position).normalized * 12;
                // Envoie le clone dans une direction fixe.
                shot = true;
            }
        }
    }

    IEnumerator WaitAndShot()
    {
        randShoot = Random.Range(0, 3);

        if (randShoot == 0)
        {
            twoWays = true;
            fourWays = false;
            eightWays = false;
        }
        else if (randShoot == 1)
        {
            twoWays = false;
            fourWays = true;
            eightWays = false;
        }
        else if (randShoot == 2)
        {
            twoWays = false;
            fourWays = false;
            eightWays = true;
        }

        randTime = Random.Range(1, 4);

        yield return new WaitForSeconds(randTime);
        shot = false;
    }
}
