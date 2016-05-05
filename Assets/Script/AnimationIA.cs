using UnityEngine;
using System.Collections;

public class AnimationIA : MonoBehaviour {

    public Animator feet;
    public Animator body;
    private bool vertical;
    private bool attack;
    private Transform player;
	
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

	void Update ()
    {
	
        if ( this.gameObject.name == "Corps 1")
        {
            feet.SetBool("Vertical", vertical);
            body.SetBool("Vertical", vertical);
            body.SetBool("MonstreAttack", attack);

            if (player.transform.position.z > this.gameObject.transform.position.z)
            {
                vertical = true;
            }
            else
            {
                vertical = false;
            }

        }
        else if (this.gameObject.name == "Corps 2")
        {
            print("loutre");
        }
        else if (this.gameObject.name == "Corps 3")
        {
            print("loutre");
        }
        else if(this.gameObject.name == "Corps 4")
        {
            print("loutre");
        }
        else if(this.gameObject.name == "Corps 5")
        {
            print("loutre");
        }
        else if(this.gameObject.name == "Corps 6")
        {
            print("loutre");
        }

    }

    IEnumerator WaitAndStopAttack()
    {
        yield return new WaitForSeconds(0.25f);
        attack = false;
    }
}
