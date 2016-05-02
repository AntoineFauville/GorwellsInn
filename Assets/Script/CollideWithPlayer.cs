using UnityEngine;
using System.Collections;

public class CollideWithPlayer : MonoBehaviour {

	public Personnage playerInfo;
    public GameObject corps;
    public IATentacles tentacule;
    public int nbreTentacule;

    void Start()
    {
		playerInfo = GameObject.Find("Player").GetComponent<Personnage>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && corps.tag != "Dead")
        {
            playerInfo.TakeDamage();
        }

        if (collision.gameObject.tag == "Weapon")
        {
            tentacule.follow[nbreTentacule] = false;
        }
    }
}
