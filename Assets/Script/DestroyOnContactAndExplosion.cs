using UnityEngine;
using System.Collections;

public class DestroyOnContactAndExplosion : MonoBehaviour {

    public Rigidbody explosion;

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Sol" && other.gameObject.tag != "Normal" && other.gameObject.tag != "Easy" && other.gameObject.tag != "Trap" && other.gameObject.tag != "Slower" && other.gameObject.tag != "Dead" && other.gameObject.tag != "Weapon" && other.gameObject.tag != "Training")
        {
            Rigidbody clone;
            clone = Instantiate(explosion, this.transform.position, this.transform.rotation) as Rigidbody;
            Destroy(gameObject);
        }
            
    }
}