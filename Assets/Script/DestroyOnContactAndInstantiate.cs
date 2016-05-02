using UnityEngine;
using System.Collections;

public class DestroyOnContactAndInstantiate: MonoBehaviour {

    public GameObject chest;

    void OnTriggerEnter (Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
			Destroy (gameObject);
		}
	}
}
