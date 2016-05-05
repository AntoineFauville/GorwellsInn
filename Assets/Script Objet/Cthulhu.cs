using UnityEngine;
using System.Collections;

public class Cthulhu : Boss {

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
        playSound = GetComponent<AudioSource>();
    }

	public override void Update () 
	{
		base.Update();

		if (bossLife <= 0 /*&& dead == false*/)
		{
			//door.Counter ();
			touched.Stop();
			mort.SetActive (true);
			base.Death ();
		}

		if (this.gameObject.tag != "Dead") 
		{
			touched.SetBool ("Touched", hit);
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
}
