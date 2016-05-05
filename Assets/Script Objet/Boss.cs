using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	/* Porte */
	public ChangeMapUnique door;
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

	public virtual void Start () 
	{
		life = GameObject.Find ("TriggerEasyLaunchGame").GetComponent<LaunchTimer> ();
		bossLife = Mathf.Round (life.LifeBar.fillAmount * 20);
        player = GameObject.Find("Player").GetComponent<Personnage>();
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
