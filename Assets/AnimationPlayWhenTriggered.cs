using UnityEngine;
using System.Collections;

public class AnimationPlayWhenTriggered : MonoBehaviour {

    public Animator animator;
	public GameObject corps;
	private GameObject player;

	void Start()
	{
		player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (corps.gameObject.tag != "Dead") 
		{
			RaycastHit hit;
			Vector3 rayDirection = player.transform.position - transform.position;

			if (Vector3.Angle (rayDirection, transform.forward) <= 720 * 0.5f) {

				if (Physics.Raycast(transform.position,rayDirection, out hit, 2f)) {

					animator.SetBool("MonstreAttack", true);
				}
				else 
				{
					animator.SetBool("MonstreAttack", false);
				}
			}
		}
	}

   	/*void OnTriggerEnter(Collider collider) 
	{
		if (collider.gameObject.tag == "Player" && corps.gameObject.tag != "Dead" && collider.gameObject.tag != "Weapon") 
		{
			animator.SetBool("MonstreAttack", true);
        }
    }*/
    /*void OnTriggerExit(Collider collider)
    {
		if (collider.gameObject.tag == "Player" && corps.gameObject.tag != "Dead" && collider.gameObject.tag != "Weapon")
        {
			animator.SetBool("MonstreAttack", true);
        }
    }*/
}
