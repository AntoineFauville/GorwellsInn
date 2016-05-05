using UnityEngine;
using System.Collections;

public class Owl : Boss {

	/* Mouvement */
	private NavMeshAgent path;
	private Personnage joueur;
    /**/

    /* Sounds */
    private AudioSource playSound;
    public AudioClip[] soundsHurt;
    /**/

    /* Mort */
    public Animator touched;
	public GameObject mort;
	/**/

	public override void Start () 
	{
		base.Start();

		path = GetComponent<NavMeshAgent> ();
        joueur = GameObject.Find ("Player").GetComponent<Personnage> ();
        playSound = GetComponent<AudioSource>();
	}

	public override void Update () 
	{
		base.Update();

		if (bossLife <= 0 /*&& dead == false*/)
		{
			//door.Counter ();
			path.enabled = false;
			touched.Stop();
			mort.SetActive (true);
		}

		if (this.gameObject.tag != "Dead") 
		{
			touched.SetBool ("Touched", hit);
			Mouvement ();
		}
	}

    public override void OnTriggerEnter(Collider contact)
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
                    int nbresound = Random.Range(0, 3);
                    playSound.PlayOneShot(soundsHurt[nbresound], 1.0f);
                    life.Diminution();
                    StartCoroutine(InvicibleFrame());
                }
            }
        }
    }

	public void  Mouvement()
	{
		// On récupére la position du joueur afin que l'IA se dirige vers celui-ci.
		float dist = Vector3.Distance(joueur.transform.position, transform.position);
		// Condition afin qu'il récupére toujours la position du joueur si il est suffisamment éloigné.
		if (dist > 2)
		{
			path.destination = joueur.transform.position;
		}
	}
}
