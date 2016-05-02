using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathBoss : MonoBehaviour {

    public GameObject death;
    public ChangeMapUnique deathTime;
    public FollowingPlayer AhahFollow;
    public FireBallBehaviorStatic rangedAttack;
    public NavMeshAgent navMove;
    public GameObject corpse;
    public GameObject[] body;
    public Animator anim;
    public Animator SpecAttack;
    public float bossLife = 0;
    private int bodyPart = 0;
    private bool damagable = true;
    private bool hit = false;

    public LaunchTimer lifeSupp;
    private bool dead = false;
    private CaracDeplacement joueur;
    private LaunchTimer easy;

	private AudioSource playSound;
	public AudioClip[] soundsHurt; 

    void Start()
    {
        //bossLife = Random.Range(10,16);
		playSound = GetComponent<AudioSource>();
        joueur = GameObject.Find("Player").GetComponent<CaracDeplacement>();
        easy = GameObject.Find("TriggerEasyLaunchGame").GetComponent<LaunchTimer>();
        bossLife = bossLife + Mathf.Round(lifeSupp.LifeBar.fillAmount * 20);
    }

    void Update()
    {
        anim.SetBool("Touched", hit);

        if (bossLife <= 0 && dead == false)
        {
            if ( easy.easyMode == true )
            {
                joueur.Life.fillAmount = 1;
            }

            dead = true;
            //lifeSupp.gainLife = true;
            lifeSupp.LifeBar.fillAmount = 0;
            anim.Stop();
            SpecAttack.Stop();
            AhahFollow.enabled = false;
            rangedAttack.enabled = false;
            navMove.enabled = false;
            death.SetActive(true);
            deathTime.Counter();
            corpse.tag = "Dead";
            Death();
        }
    }

    void Death()
    {
        while (bodyPart < body.Length)
        {
            body[bodyPart].SetActive(false);
            bodyPart++;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            if (coll.gameObject.tag == "Weapon")
            {
                if (damagable == true)
                {
					int nbresound = Random.Range (0, 3);

                    damagable = false;
                    hit = true;
                    bossLife--;
					//playSound.PlayOneShot(soundsHurt[nbresound],1.0f);
                    lifeSupp.Diminution();
                    //joueur.GetLife();
                    StartCoroutine(InvicibleFrame());
                    // Jouez animation touché.
                }
            }
        }
    }

    IEnumerator InvicibleFrame()
    {
        // Coroutine empechant le joueur d'être touché plusieurs fois d'affilé en moins de 0.6 secondes.
        yield return new WaitForSeconds(0.6f);
        damagable = true;
        hit = false;
    }
}
