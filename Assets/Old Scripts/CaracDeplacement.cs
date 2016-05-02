using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaracDeplacement : MonoBehaviour {

    public float moveSpeed = 25.0f;
    public Rigidbody rigid;
    private Vector3 movement;
    private float inputZ;
    private float inputX;

    public Image Life;
    private bool damagable = true;
    private bool slow = false;
    public bool hit = false;
    public bool dead = false;
    public Transform SpawnPlace;
    public Transform BloodPrefab;
    private Transform blood;
    public Animator Hit;

    public Camera cam;
	public GameObject posCimetiere;
	public GameObject posCamCimetiere;
	public GameObject posTraining;
    public GameObject gameOver;

    public GameObject warrior;
    public GameObject Archer;
    public GameObject Mage;

    public Animator movementfeetWarrior;
    public Animator movementWarrior;
    public Animator movementfeetMage;
    public Animator movementMage;
    public Animator movementfeetArcher;
    public Animator movementArcher;
	public GameObject Mort;

	private AudioSource playSound;
	public AudioClip[] hurt;

    void Start()
    {
        Time.timeScale = 1f;

		// Remets la salle de training pour le build
		//PlayerPrefs.SetString ("Tuto", "True");

		playSound = GetComponent<AudioSource>();

		string firstTime = PlayerPrefs.GetString("Tuto");

		if (firstTime == "False" && SceneManager.GetActiveScene ().name == "Menu") {
			// position cimetiére.
			this.gameObject.transform.position = posCimetiere.transform.position;
			cam.transform.position = posCamCimetiere.transform.position;
		} 
		else if ( SceneManager.GetActiveScene ().name == "Menu")
		{
			this.gameObject.transform.position = posTraining.transform.position;
		}

		if (SceneManager.GetActiveScene ().name == "Main Scene") 
		{
			string classe = PlayerPrefs.GetString ("Classe");

			if (classe == "Warrior")
			{
				warrior.SetActive(true);
			}
			else if (classe == "Mage")
			{
				Mage.SetActive(true);
			}
			else if (classe == "Marksman")
			{
				Archer.SetActive(true);
			}
		}
			
    }

    void Update ()
    {
        if (dead != true)
        {
            // Récupération des valeurs des Axes
            inputZ = Input.GetAxis("Vertical") * moveSpeed;
            inputX = Input.GetAxis("Horizontal") * moveSpeed;
            //transform.Translate(inputX, 0, inputZ);
            movement = new Vector3(inputX, 0, inputZ);
        }
        else if (dead == true)
        {
            movement = new Vector3(0, 0, 0);
            inputX = 0;
            inputZ = 0;
            damagable = false;
        }

        // Animation Déplacement Warrior
        if ( warrior.activeSelf == true )
        {
            movementfeetWarrior.SetFloat("MarcheHorizontale", inputX);
            movementfeetWarrior.SetFloat("MarcheVerticale", inputZ);
            movementWarrior.SetFloat("MarcheHorizontale", inputX);
            movementWarrior.SetFloat("MarcheVertical", inputZ);
        }

        // Animation Déplacement Archer
        if ( Archer.activeSelf == true )
        {
            movementfeetArcher.SetFloat("MarcheHorizontale", inputX);
            movementfeetArcher.SetFloat("MarcheVerticale", inputZ);
            movementArcher.SetFloat("MarcheHorizontale", inputX);
            movementArcher.SetFloat("MarcheVertical", inputZ);
        }

        // Animation Déplacement Mage
        if ( Mage.activeSelf == true )
        {
            movementfeetMage.SetFloat("MarcheHorizontale", inputX);
            movementfeetMage.SetFloat("MarcheVerticale", inputZ);
            movementMage.SetFloat("MarcheHorizontale", inputX);
            movementMage.SetFloat("MarcheVertical", inputZ);
        }

        rigid.velocity = movement;

        Hit.SetBool("PlayerHit", hit);

        if (slow == true)
        {
            moveSpeed = 5f;
        }
        else if (slow == false)
        {
            moveSpeed = 10f;
        }

		if (SceneManager.GetActiveScene ().name == "Main scene")
        {
            if (Life.fillAmount <= 0.01f)
            {
                StartCoroutine(Die());
            }
        }
    }

    public void TakeDamage ()
    {
        // retirer un coeur de vie et jouer animation du personnage blessé.
        if (damagable == true )
        {
            damagable = false;
            hit = true;
			int nbreSound = Random.Range (0, 3);
			playSound.PlayOneShot (hurt[nbreSound],1.0f);
            Time.timeScale = 0.50f;
            Life.fillAmount = Life.fillAmount - (1/3f);
            blood = BloodPrefab;
            Instantiate(blood, SpawnPlace.position, SpawnPlace.rotation);
            StartCoroutine(InvicibleFrame());
            // Repousse le joueur aprés damage.
        }
    }

    public void GetLife()
    {
        if ( warrior.activeSelf == true)
        {
            Life.fillAmount = Life.fillAmount + 0.0165f;
        }
    }

    void OnTriggerEnter(Collider trap)
    {
        if (trap.gameObject.tag == "Trap" || trap.gameObject.tag == "IA")
        {
            TakeDamage();
        }

        if (trap.gameObject.tag == "Slower")
        {
            //moveSpeed = 5f;
            slow = true;
            StartCoroutine(SlowTime());
        }
        /*else if ( trap.gameObject.tag =="Sol")
        {
            moveSpeed = 10f;
        }*/
    }

    void OnTriggerStay(Collider trap)
    {
        if (trap.gameObject.tag == "Slower")
        {
            //moveSpeed = 5f;
            slow = true;
            StartCoroutine(SlowTime());
        }
        /*else if (trap.gameObject.tag =="Sol")
        {
            moveSpeed = 10f;
        }*/
    }

    IEnumerator InvicibleFrame()
    {
        // Coroutine empechant le joueur d'être touché plusieurs fois d'affilé en moins de 0.6 secondes.
        yield return new WaitForSeconds(0.6f);
        damagable = true;
        hit = false;
        Time.timeScale = 1f;
    }

    IEnumerator SlowTime()
    {
        if (slow == true)
        {
            yield return new WaitForSeconds(0.6f);
            slow = false;
        }
    }

    IEnumerator Die()
    {
        Time.timeScale = 0.75f;
        dead = true;

		if (Mage.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Mage");
		}
		else if (Archer.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Marksman");
		}
		else if (warrior.activeSelf == true)
		{
			PlayerPrefs.SetString ("Classe", "Warrior");
		}
			
		Mort.SetActive (true);
		Archer.SetActive(false);
		Mage.SetActive(false);
		warrior.SetActive(false);
        yield return new WaitForSeconds(3f);
        gameOver.SetActive(true);
        cam.transform.position = new Vector3(0, 50, 75.6f);
        Time.timeScale = 1f;
    }
}
