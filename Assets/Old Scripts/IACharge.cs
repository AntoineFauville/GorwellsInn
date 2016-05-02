using UnityEngine;
using System.Collections;

public class IACharge : MonoBehaviour {
	
	public Transform player;
	public Personnage playerInfo;
    Rigidbody corps;
    private int randTime;
	private bool charge = true;
	
	void Start()
	{
        player = GameObject.Find("Player").GetComponent<Transform>();
		playerInfo = GameObject.Find("Player").GetComponent<Personnage>();
        corps = GetComponent<Rigidbody>();
        StartCoroutine(WaitAndCharge());
    }
	
	void Update()
	{
		if (charge == false && corps.tag != "Dead")
		{
			StartCoroutine(WaitAndCharge());
            Charge();
        }
	}
	
	public void Charge()
	{
		corps.velocity = (player.transform.position - transform.position).normalized * 20;
        // Cette ligne permet de cibler vers le joueur.
		charge = true;	
	}
	
	void OnCollisionEnter(Collision coll)
    {
        if ( coll.gameObject.tag == "Player" && this.gameObject.tag != "Dead")
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
	
	IEnumerator WaitAndCharge()
    {
        randTime = Random.Range(3,7);

        yield return new WaitForSeconds(randTime);
        charge = false;
    }
}