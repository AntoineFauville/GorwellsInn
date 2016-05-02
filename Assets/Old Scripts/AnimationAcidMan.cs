using UnityEngine;
using System.Collections;

public class AnimationAcidMan : MonoBehaviour {

    public Animator feet;
    public Animator body;
    private bool vertical;
    private bool attack;
    private Transform player;
    private Transform corpse;
    private FollowingPlayer acidman;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        corpse = GameObject.Find("Corps 6").transform;
    }

    void Update()
    {
        acidman = this.gameObject.GetComponent<FollowingPlayer>();

        if (corpse.tag != "Dead")
        {
            /*feet.SetBool("Vertical", vertical);
            body.SetBool("Vertical", vertical);
            body.SetBool("MonstreAttack", attack);*/
        }

        if (player.transform.position.z > this.gameObject.transform.position.z)
        {
            vertical = true;
			feet.SetBool("Vertical", true);
			body.SetBool("Vertical", true);
        }
        else
        {
            vertical = false;
			feet.SetBool("Vertical", false);
			body.SetBool("Vertical", false);
        }

        /*if (acidman.damaging == true)
        {
            attack = true;
            StartCoroutine(WaitAndStopAttack());
        }*/
    }

    IEnumerator WaitAndStopAttack()
    {
        yield return new WaitForSeconds(0.25f);
        attack = false;
    }
}
