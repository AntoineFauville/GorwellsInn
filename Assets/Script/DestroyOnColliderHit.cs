using UnityEngine;
using System.Collections;

public class DestroyOnColliderHit : MonoBehaviour {

	//public Transform explosionPrefab;

	void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Decoration")
        {
            Destroy(gameObject);
        }

		if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Sol" && collision.gameObject.tag != "Normal" && collision.gameObject.tag != "Easy" && collision.gameObject.tag != "Trap" && collision.gameObject.tag != "Dead" && collision.gameObject.tag != "Slower" && collision.gameObject.tag != "Training" ) 
		{
			Destroy(gameObject);
		}
	}
}
