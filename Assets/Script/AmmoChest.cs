using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoChest : MonoBehaviour {

    // Script permettant de faire apparaitre des munitions lorsque le joueur touche le coffre

    public Rigidbody ammoPrefab;
    public DestroyOnContactAndInstantiate chestSpawn;
    private bool spawn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && spawn == false)
        {
            spawn = true;
            Instantiate(ammoPrefab, this.transform.position, this.transform.rotation);
            Destroy (this.gameObject);
		}
    }
}
