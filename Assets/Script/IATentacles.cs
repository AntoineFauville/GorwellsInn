using UnityEngine;
using System.Collections;

public class IATentacles : MonoBehaviour {

    public Transform player;
    private Personnage playerInfo;
    [SerializeField]
    public bool[] follow;
    public Transform[] posIni;
    public GameObject[] tentacles;
    private int randNbr;
    public GameObject corps;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerInfo = GameObject.Find("Player").GetComponent<Personnage>();
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
            tentacles[0].GetComponent<AILerpPursuit>().enabled = true;
        }
        else if (follow[0] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[0].GetComponent<AILerpPursuit>().enabled = false;
        }

        if (follow[1] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[1].GetComponent<AILerpPursuit>().enabled = true;
        }
        else if (follow[1] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[1].GetComponent<AILerpPursuit>().enabled = false;
        }

        if (follow[2] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[2].GetComponent<AILerpPursuit>().enabled = true;
        }
        else if (follow[2] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[2].GetComponent<AILerpPursuit>().enabled = false;
        }

        if (follow[3] == true && corps.gameObject.tag != "Dead")
        {
            tentacles[3].GetComponent<AILerpPursuit>().enabled = true;
        }
        else if (follow[3] == false && corps.gameObject.tag != "Dead")
        {
            tentacles[3].GetComponent<AILerpPursuit>().enabled = false;
        }

        if (corps.gameObject.tag == "Dead")
        {
            for(int i = 0;i < 4;i++)
            {
                follow[i] = false;
            }
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
