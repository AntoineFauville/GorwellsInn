using UnityEngine;
using System.Collections;

public class IATentacles : MonoBehaviour {

    public Transform player;
    public CaracDeplacement playerInfo;
    [SerializeField]
    public bool[] follow;
    public Transform[] posIni;
    public NavMeshAgent[] tentacles;
    private int randNbr;
    public GameObject corps;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerInfo = GameObject.Find("Player").GetComponent<CaracDeplacement>();
        randNbr = Random.Range(1, 5);
        follow[0] = false;
        follow[1] = false;
        follow[2] = false;
        follow[3] = false;

        StartCoroutine(WaitAndStop());
    }

    void Update()
    {
        if (follow[0] == true && corps.gameObject.tag !="Dead")
        {
            tentacles[0].destination = player.transform.position;
        }
        else if (follow[0] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[0].destination = posIni[0].position;
        }

        if (follow[1] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[1].destination = player.transform.position;
        }
        else if (follow[1] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[1].destination = posIni[1].position;
        }

        if (follow[2] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[2].destination = player.transform.position;
        }
        else if (follow[2] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[2].destination = posIni[2].position;
        }

        if (follow[3] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[3].destination = player.transform.position;
        }
        else if (follow[3] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[3].destination = posIni[3].position;
        }
    }

    void Follow()
    {
        StartCoroutine(WaitAndGo());
    }

    void NotFollow()
    {
        StartCoroutine(WaitAndStop());
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
        {
            playerInfo.TakeDamage();
        }
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
        {
            playerInfo.TakeDamage();
        }
    }

    IEnumerator WaitAndGo()
    {
        follow[0] = true;
        follow[1] = true;
        follow[2] = true;
        follow[3] = true;
        randNbr = Random.Range(1, 5);
        yield return new WaitForSeconds(8);
        NotFollow();
    }

    IEnumerator WaitAndStop()
    {
        follow[0] = false;
        follow[1] = false;
        follow[2] = false;
        follow[3] = false;
        yield return new WaitForSeconds(6);
        Follow();
    }
}
