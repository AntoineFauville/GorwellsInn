using UnityEngine;
using System.Collections;

public class DestroyOnColliderHitIAVersion : MonoBehaviour {

	public Personnage playerInfo;

    void Start()
    {
		playerInfo = GameObject.Find("Player").GetComponent<Personnage>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInfo.TakeDamage();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }    
    }
}
