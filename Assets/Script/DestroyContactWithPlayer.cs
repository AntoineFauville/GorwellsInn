using UnityEngine;
using System.Collections;

public class DestroyContactWithPlayer : MonoBehaviour {

	public void OnTriggerEnter(Collider touch)
    {
        if (touch.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
