using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personnage : MonoBehaviour {

	/* Déplacement */
	protected float inputX;
	protected float inputZ;
	float moveSpeed;
	private Vector3 movement;
	protected Rigidbody rigid;
    private Transform slowIndicator;
	/**/

	/* Vie */
	public Image life;
	private bool damagable = true;
	private bool slow = false;
    private bool speedUpTime = false;
    Animator hitAnimation;
	/**/

	/* Mort */
	public bool dead = false;
	private Transform warriorSprite;
	private Transform marksmanSprite;
	private Transform mageSprite;
	private Transform mort;
	private Transform gameOver;
	private Camera cam;
	/**/

	/* Menu */
	private GameObject posCimetiere;
	private GameObject posCamCimetiere;
	private GameObject posTraining;
	string firstTime;
	/**/

	/* Attaque */
	protected Transform up;
	protected Transform down;
	protected Transform right;
	protected Transform left;
	private bool training = false;
	public bool fireRate = false;
	protected bool upAttack = false;
	protected bool downAttack = false;
	protected bool rightAttack = false;
	protected bool leftAttack = false;
	protected Vector3 vectorUp;
	protected Vector3 vectorUp2;
	protected Vector3 vectorDown;
	protected Vector3 vectorDown2;
	protected Vector3 vectorRight;
	protected Vector3 vectorRight2;
	protected Vector3 vectorLeft;
	protected Vector3 vectorLeft2;
	protected Vector3 pos2;
	/**/

	/* Bruitages */
	private AudioSource playSound;
	public AudioClip[] hurt;
	/**/

	/* Constructeur */

	public Personnage()
	{
		moveSpeed = 10.0f;
	}
	/**/
		

	public virtual void Start () 
	{
		LinkGameobject ();

		if (SceneManager.GetActiveScene ().name == "Main Scene")
		{
			MainScene ();
		}
			
		if (SceneManager.GetActiveScene ().name == "Menu") 
		{
			MenuScene ();
		}
			

	}

	public virtual void Update () 
	{
		if (dead == true) 
		{
			movement = new Vector3(0, 0, 0);
			inputX = 0;
			inputZ = 0;
			damagable = false;
			fireRate = false;
			upAttack = false;
			downAttack = false;
			rightAttack = false;
			leftAttack = false;
		}
		else 
		{
			inputX = Input.GetAxis ("Horizontal") * moveSpeed;
			inputZ = Input.GetAxis ("Vertical") * moveSpeed;
			movement = new Vector3 (inputX, 0, inputZ);
		}

		if (rigid != null) {
			rigid.velocity = movement;
		}

		if (Input.GetButtonDown ("AttackUp") && training == true || Input.GetButtonDown ("AttackUp") && SceneManager.GetActiveScene ().name == "Main Scene" ) 
		{
			AttackUp ();
		}

		if (Input.GetButtonDown ("AttackDown") && training == true || Input.GetButtonDown ("AttackDown") && SceneManager.GetActiveScene ().name == "Main Scene") 
		{
			AttackDown ();
		}

		if (Input.GetButtonDown ("AttackLeft") && training == true || Input.GetButtonDown ("AttackLeft") && SceneManager.GetActiveScene ().name == "Main Scene") 
		{
			AttackLeft ();
		}

		if (Input.GetButtonDown ("AttackRight") && training == true || Input.GetButtonDown ("AttackRight") && SceneManager.GetActiveScene ().name == "Main Scene") 
		{
			AttackRight ();
		}

		if (slow == true) 
		{
			moveSpeed = 5f;
		}
		else if (slow == false) 
		{
			moveSpeed = 10f;
		}

        if (speedUpTime == true)
        {
            moveSpeed = 15f;
        }
        else if (speedUpTime == false)
        {
            moveSpeed = 10f;
        }

		if (SceneManager.GetActiveScene ().name == "Main Scene") 
		{
			if (life.fillAmount <= 0.01f) 
			{
				StartCoroutine (Die ());
			}	
		}
	}

	public void TakeDamage()
	{
		if (damagable == true) 
		{
			damagable = false;
			hitAnimation.SetBool ("PlayerHit", true);
			int nbreSound = Random.Range (0, 3);
			playSound.PlayOneShot (hurt [nbreSound], 1.0f);
			Time.timeScale = 0.50f;
			life.fillAmount = life.fillAmount - (1/3f);
			StartCoroutine (InvicibleFrame ());
		}
	}

	public void  LinkGameobject()
	{
		rigid = GetComponent<Rigidbody> ();
		GameObject player = GameObject.Find ("Player");
		Transform sprites = player.transform.Find ("SpriteDuJoueur");
		warriorSprite = sprites.transform.Find ("Guerrier");
		marksmanSprite = sprites.transform.Find ("Archer");
		mageSprite = sprites.transform.Find ("Mage");
		mort = sprites.transform.Find("Mort");
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		playSound = GetComponent<AudioSource> ();
		firstTime = PlayerPrefs.GetString("Tuto");
		hitAnimation = player.GetComponent<Animator> ();
		up = player.transform.Find ("TopSpawnPrefabWeaponPoint");
		down = player.transform.Find ("DownSpawnPrefabWeaponPoint");
		right = player.transform.Find ("RightSpawnPrefabWeaponPoint");
		left = player.transform.Find ("LeftSpawnPrefabWeaponPoint");
        slowIndicator = player.transform.Find("SpriteDuJoueur/IndicatorSlow");

    }

	public void MenuScene()
	{
		posCimetiere = GameObject.Find("PlayerSpawnDead");
		posCamCimetiere = GameObject.Find("Camera Cimetiere");
		posTraining = GameObject.Find("PlayerSpawnArrivéeEnJeu");

		if (firstTime == "False") {
			// position cimetiére.
			this.gameObject.transform.position = posCimetiere.transform.position;
			cam.transform.position = posCamCimetiere.transform.position;
		} 
		else 
		{
			// position Salle d'entrainement
			this.gameObject.transform.position = posTraining.transform.position;
		}
	}

	public virtual void MainScene()
	{
		GameObject canvas = GameObject.Find ("Canvas");
		Transform panel = canvas.transform.Find ("Panel");
		Transform coeur = panel.transform.Find ("Coeur");
		life = coeur.transform.Find ("CoeurSprite").GetComponent<Image> ();
		gameOver = canvas.transform.Find ("GameOverPanel");
		string classe = PlayerPrefs.GetString ("Classe");

		if (classe == "Warrior")
		{
			warriorSprite.gameObject.SetActive (true);
		}
		else if (classe == "Mage")
		{
			mageSprite.gameObject.SetActive(true);
		}
		else if (classe == "Marksman")
		{
			marksmanSprite.gameObject.SetActive(true);
		}
	}

	public virtual void AttackUp()
	{
		float randDev = Random.Range(-0.08f, 0.09f);
		vectorUp = new Vector3(randDev, 0, 1);
		float randDev2 = Random.Range(-0.08f, 0.09f);
		vectorUp2 = new Vector3(randDev2, 0, 1);
		pos2 = new Vector3(up.transform.position.x+1, up.transform.position.y, up.transform.position.z);
		upAttack = true;
		StartCoroutine(EndAttack(0.4f));
	}

	public virtual void AttackDown()
	{
		float randDev = Random.Range(-0.08f, 0.09f);
		vectorDown = new Vector3(randDev, 0, -1);
		float randDev2 = Random.Range(-0.08f, 0.09f);
		vectorDown2 = new Vector3(randDev2, 0, -1);
		pos2 = new Vector3(down.transform.position.x + 1, down.transform.position.y, down.transform.position.z);
		downAttack = true;
		StartCoroutine(EndAttack(0.4f));
	}

	public virtual void AttackRight()
	{
		float randDev = Random.Range(-0.08f, 0.09f);
		vectorRight = new Vector3(1, 0, randDev);
		float randDev2 = Random.Range(-0.08f, 0.09f);
		vectorRight2 = new Vector3(1, 0, randDev2);
		pos2 = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z + 1);
		rightAttack = true;
		StartCoroutine(EndAttack(0.4f));
	}

	public virtual void AttackLeft()
	{
		float randDev = Random.Range(-0.08f, 0.09f);
		vectorLeft = new Vector3(-1, 0, randDev);
		float randDev2 = Random.Range(-0.08f, 0.09f);
		vectorLeft2 = new Vector3(-1, 0, randDev2);
		pos2 = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z + 1);
		leftAttack = true;
		StartCoroutine(EndAttack(0.4f));
	}

	void OnTriggerEnter(Collider trap)
	{
		if (trap.gameObject.tag == "Trap" || trap.gameObject.tag == "IA") 
		{
			TakeDamage ();
		} 
		else if (trap.gameObject.tag == "Slower") 
		{
			slow = true;
            slowIndicator.gameObject.SetActive(true);
			StartCoroutine (SlowTime ());
		}
        else if (trap.gameObject.tag == "SpeedUp")
        {
            speedUpTime = true;
            StartCoroutine(SpeedUpTime());
        }
		else if (trap.gameObject.tag == "Training")
		{
			training = true;
		}
	}

	void OnTriggerStay(Collider trap)
	{
		if (trap.gameObject.tag == "Slower") {
			slow = true;
            slowIndicator.gameObject.SetActive(true);
            StartCoroutine (SlowTime ());
		} 
		else if (trap.gameObject.tag == "Training")
		{
			training = true;
		}
	}

	void OnTriggerExit(Collider zone)
	{
		if (zone.gameObject.tag == "Training") 
		{
			//training = false;
		}
	}

	IEnumerator InvicibleFrame()
	{
		// Coroutine empechant le joueur de prendre des dégats le tuant en moins d'une seconde.
		yield return new WaitForSeconds (0.6f);
		damagable = true;
		hitAnimation.SetBool ("PlayerHit", false);
		Time.timeScale = 1f;
	}

	IEnumerator SlowTime()
	{
		if (slow == true) 
		{
			yield return new WaitForSeconds (0.6f);
			slow = false;
            slowIndicator.gameObject.SetActive(false);
        }
	}

    IEnumerator SpeedUpTime()
    {
        if (speedUpTime == true)
        {
            yield return new WaitForSeconds(1.1f);
            speedUpTime = false;
        }
    }

	IEnumerator Die()
	{
		Time.timeScale = 0.75f;
		dead = true;

		if (mageSprite.gameObject.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Mage");
		}
		else if (marksmanSprite.gameObject.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Marksman");
		}
		else if (warriorSprite.gameObject.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Warrior");
		}

		mort.gameObject.SetActive (true);
		marksmanSprite.gameObject.SetActive(false);
		mageSprite.gameObject.SetActive(false);
		warriorSprite.gameObject.SetActive(false);
		yield return new WaitForSeconds(3f);
		gameOver.gameObject.SetActive(true);
		cam.transform.position = new Vector3(0, 50, 75.6f);
		Time.timeScale = 1f;
	}

	public IEnumerator WeaponUsed(float x)
	{
		// Coroutine empechant le joueur d'attaquer plus d'une fois toutes les x secondes.
		yield return new WaitForSeconds(x);
		fireRate = false;
	}

	public IEnumerator EndAttack(float x)
	{
		yield return new WaitForSeconds(x);
		upAttack = false;
		downAttack = false;
		rightAttack = false;
		leftAttack = false;
	}
}
