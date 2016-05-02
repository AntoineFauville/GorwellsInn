using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour {

    public FollowingPlayer AhahFollow;
    public NavMeshAgent navMove;
    public BloodSpawner blood;
    public GameObject corpse;
    private bool damagable = true;
    public bool mort = false;
    public ChangeMap countDeath;

    public int Life;

	private Personnage joueur;
	private Guerrier guerrier;

    private string area;
    public string salle;

    public Animator Mort;

    void Awake()
    {
		joueur = GameObject.Find("Player").GetComponent<Personnage>();
		guerrier = joueur.transform.Find ("SpriteDuJoueur/Guerrier").GetComponent<Guerrier>();
        area = "AreaChanging" + salle;
    }

    void Start()
    {
        Mort = GetComponentInChildren<Animator>();

        countDeath = GameObject.Find(area).GetComponent<ChangeMap>();
    }

    void Update()
    {
        Mort.SetBool("Mort", mort);

        if (Life <= 0.1 && mort != true)
        {
            navMove.enabled = false;
            blood.spawning = false;
            mort = true;
            corpse.tag = "Dead";
            countDeath.Counter();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Trap" && this.gameObject.tag != "Dead")
        {
            if (coll.gameObject.tag == "Weapon")
            {
                if ( damagable == true)
                {
                    Life--;
                    damagable = false;
					guerrier.LifeStealing(); //Récup vie Guerrier.
                    StartCoroutine(InvicibleFrame());
                }
            }
        }
    }

    IEnumerator InvicibleFrame()
    {
        // Coroutine empechant le joueur d'être touché plusieurs fois d'affilé en moins de 0.6 secondes.
        yield return new WaitForSeconds(0.6f);
        damagable = true;
    }
}
