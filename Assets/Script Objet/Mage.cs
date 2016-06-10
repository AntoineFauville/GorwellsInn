using UnityEngine;
using System.Collections;

public class Mage : Personnage {

	/* Animations */
	private Animator magician;
	private Animator magicianFeet;
	/**/

	/* Attaque */
	public GameObject weapon;
	private GameObject clone;
	private Rigidbody attack;
	/**/

	/* Bruitages */
	private AudioSource playSoundMage;
	public AudioClip[] soundsMage;
	/**/

	public override void Start () 
	{
		base.Start ();
		
		GameObject anim;
		anim = GameObject.Find ("Mage");
		magician = anim.transform.Find ("HautDuCorps").GetComponent<Animator>();
		magicianFeet = anim.transform.Find ("Pied").GetComponent<Animator>();
		playSoundMage = anim.GetComponent<AudioSource> ();

        if (PlayerPrefs.GetInt("MageVictory") > 0)
        {
            weapon = Resources.Load("Boulet Second") as GameObject;
        }

    }

	public override void Update () 
	{
		base.Update();

		if (base.tag != "Dead") 
		{
			magician.SetFloat ("MarcheHorizontale", inputX);
			magician.SetFloat ("MarcheVertical", inputZ);
			magician.SetBool("FlecheHaut", upAttack);
			magician.SetBool("FlecheBas", downAttack);
			magician.SetBool("FlecheDroite", rightAttack);
			magician.SetBool("FlecheGauche", leftAttack);
			magicianFeet.SetFloat ("MarcheHorizontale", inputX);
			magicianFeet.SetFloat ("MarcheVerticale", inputZ);
		}
	}

	public void Sound()
	{
		int nbreSound = Random.Range (0, 3);
		playSoundMage.PlayOneShot (soundsMage [nbreSound], 0.7f);
	}

	public override void AttackUp()
	{
		base.AttackUp ();

		weapon.transform.rotation = Quaternion.Euler (0, 0, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,up.transform.position,weapon.transform.rotation) as GameObject;
		
			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(up.transform.forward * 650 );
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (1.2f));
		}
	}

	public override void AttackDown()
	{
		base.AttackDown ();

		weapon.transform.rotation = Quaternion.Euler (0, 180, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,down.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(-down.transform.forward * 650 );
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (1.2f));
		}
	}

	public override void AttackRight()
	{
		base.AttackRight ();

		weapon.transform.rotation = Quaternion.Euler (0, 90, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,right.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(right.transform.right * 650 );
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (1.2f));
		}
	}

	public override void AttackLeft()
	{
		base.AttackLeft ();

		weapon.transform.rotation = Quaternion.Euler (0, 270, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,left.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(-left.transform.right * 650 );
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (1.2f));
		}
	}
}
