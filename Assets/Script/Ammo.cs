using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

    // Script gérant la destruction des munitions sur le terrain lorsque le joueur les touchent.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
    }
}
