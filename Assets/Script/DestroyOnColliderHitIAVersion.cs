using UnityEngine;
using System.Collections;

public class DestroyOnColliderHitIAVersion : MonoBehaviour {

	public Personnage player;

    void Start()
    {
		player = GameObject.Find("Player").GetComponent<Personnage>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }    
    }
}
