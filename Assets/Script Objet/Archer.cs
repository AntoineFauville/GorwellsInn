using UnityEngine;
using System.Collections;

public class Archer : Personnage {

	/* Animations */
	private Animator marksman;
	private Animator marksmanFeet;
	/**/

	/* Attaque */
	public GameObject weapon;
	private GameObject clone;
	private Rigidbody attack;
	private int nbreTir = 0;
	/**/

	/* Bruitages */
	private AudioSource playSoundMarksman;
	public AudioClip[] soundsMarksman;
	/**/

	public override void Start()
	{
		base.Start ();
		GameObject anim;
		anim = GameObject.Find ("Archer");
		marksman = anim.transform.Find ("HautDuCorps").GetComponent<Animator>();
		marksmanFeet = anim.transform.Find ("Pied").GetComponent<Animator>();
		playSoundMarksman = anim.GetComponent<AudioSource> ();
	}

	public override void Update () 
	{
		base.Update();

		if (base.tag != "Dead") 
		{
			marksman.SetFloat ("MarcheHorizontale", inputX);
			marksman.SetFloat ("MarcheVertical", inputZ);
			marksman.SetBool("FlecheHaut", upAttack);
			marksman.SetBool("FlecheBas", downAttack);
			marksman.SetBool("FlecheDroite", rightAttack);
			marksman.SetBool("FlecheGauche", leftAttack);
			marksmanFeet.SetFloat ("MarcheHorizontale", inputX);
			marksmanFeet.SetFloat ("MarcheVerticale", inputZ);
		}
	}

	public void Sound()
	{
		int nbreSound = Random.Range (0, 3);
		playSoundMarksman.PlayOneShot (soundsMarksman [nbreSound], 0.7f);
	}

	public override void AttackUp()
	{
		base.AttackUp ();

		weapon.transform.rotation = Quaternion.Euler (0, 0, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			nbreTir++;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,up.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(vectorUp * 1000 );
			}

			if (nbreTir == 3)
			{
				clone = Instantiate(weapon, pos2, weapon.transform.rotation) as GameObject;
				attack = clone.GetComponent<Rigidbody> ();
				attack.AddForce(vectorUp2 * 1000);
				nbreTir = 0;
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (0.7f));
		}
	}

	public override void AttackDown()
	{
		base.AttackDown ();

		weapon.transform.rotation = Quaternion.Euler (0, 180, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			nbreTir++;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,down.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(vectorDown * 1000 );
			}

			if (nbreTir == 3)
			{
				clone = Instantiate(weapon, pos2, weapon.transform.rotation) as GameObject;
				attack = clone.GetComponent<Rigidbody> ();
				attack.AddForce(vectorDown2 * 1000);
				nbreTir = 0;
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (0.7f));
		}
	}

	public override void AttackRight()
	{
		base.AttackRight ();

		weapon.transform.rotation = Quaternion.Euler (0, 90, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			nbreTir++;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,right.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(vectorRight * 1000 );
			}

			if (nbreTir == 3)
			{
				clone = Instantiate(weapon, pos2, weapon.transform.rotation) as GameObject;
				attack = clone.GetComponent<Rigidbody> ();
				attack.AddForce(vectorRight2 * 1000);
				nbreTir = 0;
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (0.7f));
		}
	}

	public override void AttackLeft()
	{
		base.AttackLeft ();

		weapon.transform.rotation = Quaternion.Euler (0, 270, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			nbreTir++;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			clone = Instantiate(weapon,left.transform.position,weapon.transform.rotation) as GameObject;

			attack = clone.GetComponent<Rigidbody>();

			if (clone != null) 
			{
				attack.AddForce(vectorLeft * 1000 );
			}

			if (nbreTir == 3)
			{
				clone = Instantiate(weapon, pos2, weapon.transform.rotation) as GameObject;
				attack = clone.GetComponent<Rigidbody> ();
				attack.AddForce(vectorLeft2 * 1000);
				nbreTir = 0;
			}
			Sound ();
			StartCoroutine (base.WeaponUsed (0.7f));
		}
	}
}
