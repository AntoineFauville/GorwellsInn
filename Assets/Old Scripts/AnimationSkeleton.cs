using UnityEngine;
using System.Collections;

public class AnimationSkeleton : MonoBehaviour {

    public Animator feet;
    public Animator body;
    private bool vertical;
    private bool attack;
    private Transform player;
    private Transform corpse;
    private FollowingPlayer skeleton;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        corpse = GameObject.Find("Corps 4").transform;
    }

    void Update()
    {
        skeleton = this.gameObject.GetComponent<FollowingPlayer>();

        if (corpse.tag != "Dead")
        {
            feet.SetBool("Vertical", vertical);
            body.SetBool("Vertical", vertical);
            body.SetBool("MonstreAttack", attack);
        }

        if (player.transform.position.z > this.gameObject.transform.position.z)
        {
            vertical = true;
        }
        else
        {
            vertical = false;
        }

        if (skeleton.damaging == true)
        {
            attack = true;
            StartCoroutine(WaitAndStopAttack());
        }
    }

    IEnumerator WaitAndStopAttack()
    {
        yield return new WaitForSeconds(0.25f);
        attack = false;
    }
}
