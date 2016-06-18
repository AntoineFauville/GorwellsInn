using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	/* Porte */
	public ChangeMapUnique door;
    private DataBase data;
    private Transform map;
    public int salle;
    private Mapper nbreRoom;
    /**/

    /* Vie */
    protected float bossLife;
	protected LaunchTimer life;
	/**/

	/* Mort */
	public GameObject[] body;
	private int bodyPart = 0;
	protected bool damageable = true;
	protected bool hit = false;
	protected bool dead = false;
    private bool healedPlayer = false;
    private Personnage player;
	/**/

	public Boss()
	{
		//bossLife = 0;
	}

    void Awake()
    {
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }

	public virtual void Start () 
	{
        nbreRoom = GameObject.Find("Main Camera").GetComponent<Mapper>();
        life = GameObject.Find ("TriggerEasyLaunchGame").GetComponent<LaunchTimer> ();
        salle = data.count;
		bossLife = Mathf.Round (life.LifeBar.fillAmount * 20);
        player = GameObject.Find("Player").GetComponent<Personnage>();
        if (salle != 0)
        {
            map = nbreRoom.mapPoints[salle - 1];
            door = map.Find("Salle/AreaChanging").GetComponent<ChangeMapUnique>();
        }
    }

	public virtual void Update () 
	{
		if (bossLife <= 0 && dead == false) 
		{
			dead = true;
			life.LifeBar.fillAmount = 0;
			door.Counter ();
			this.gameObject.tag = "Dead";
			Death ();
		}
	}

	public virtual void Death()
	{
		while (bodyPart < body.Length) 
		{
			body [bodyPart].SetActive (false);
			bodyPart++;
		}

        if (PlayerPrefs.GetString("Difficulty") == "Easy" && healedPlayer == false)
        {
            healedPlayer = true;
            player.life.fillAmount = 1;
        }
    }

	public virtual void OnTriggerEnter(Collider contact)
	{
		if (contact.gameObject.tag != "Player")
		{
			if (contact.gameObject.tag == "Weapon")
			{
				if (damageable == true)
				{
					damageable = false;
					hit = true;
					bossLife--;
					life.Diminution();
					//joueur.GetLife();
					StartCoroutine(InvicibleFrame());
					// Jouez animation touché.
				}
			}
		}
	}

	public IEnumerator InvicibleFrame()
	{
		yield return new WaitForSeconds (0.6f);
		damageable = true;
		hit = false;
	}
}
