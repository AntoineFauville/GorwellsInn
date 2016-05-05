using UnityEngine;
using System.Collections;

public class ColliderDestroy : MonoBehaviour {

	public Personnage player;

    void Start()
    {
		player = GameObject.Find("Player").GetComponent<Personnage>();
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Decoration")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Sol" && collision.gameObject.tag != "Trap" && collision.gameObject.tag != "Slower" && collision.gameObject.tag != "IA" && collision.gameObject.tag != "Dead"  )
        {
            Destroy(this.gameObject);
        }
    }
}
