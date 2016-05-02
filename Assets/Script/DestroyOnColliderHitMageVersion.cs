using UnityEngine;
using System.Collections;

public class DestroyOnColliderHitMageVersion : MonoBehaviour {

    public Rigidbody explosion;
    private int pierceNbre = 0;

    void Update()
    {
        if (pierceNbre >= 4)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Decoration")
        {
            Rigidbody clone;
            clone = Instantiate(explosion, this.transform.position, this.transform.rotation) as Rigidbody;
            Destroy(gameObject);
        }
		else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Sol" && collision.gameObject.tag != "Normal" && collision.gameObject.tag != "Easy" && collision.gameObject.tag != "Trap" && collision.gameObject.tag != "Slower" && collision.gameObject.tag != "Dead" && collision.gameObject.tag != "Training")
        {
            pierceNbre++;
            Rigidbody clone;
            clone = Instantiate(explosion, this.transform.position, this.transform.rotation) as Rigidbody;
        }
    }
}
