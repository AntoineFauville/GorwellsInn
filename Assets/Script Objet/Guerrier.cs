using UnityEngine;
using System.Collections;

public class Guerrier : Personnage {

	/* Animations */
	private Animator warrior;
	private Animator warriorFeet;
	/**/

	/* Attaque */
	public GameObject weapon;
	/**/

	/* Bruitages */
	private AudioSource playSoundWarrior;
	public AudioClip[] soundsWarrior;
	/**/

	public override void Start()
	{
		base.Start ();

		GameObject anim;
		anim = GameObject.Find ("Guerrier");
		warrior = anim.transform.Find ("HautDuCorps").GetComponent<Animator>();
		warriorFeet = anim.transform.Find ("Pied").GetComponent<Animator>();
		playSoundWarrior = anim.GetComponent<AudioSource> ();
	}

	public override void Update () 
	{
		base.Update();

		if (base.tag != "Dead") 
		{
			warrior.SetFloat ("MarcheHorizontale", inputX);
			warrior.SetFloat ("MarcheVertical", inputZ);
			warrior.SetBool("FlecheHaut", upAttack);
			warrior.SetBool("FlecheBas", downAttack);
			warrior.SetBool("FlecheDroite", rightAttack);
			warrior.SetBool("FlecheGauche", leftAttack);
			warriorFeet.SetFloat ("MarcheHorizontale",inputX);
			warriorFeet.SetFloat("MarcheVerticale",inputZ);
		}
	}

	public void Sound()
	{
		int nbreSound = Random.Range (0, 3);
		playSoundWarrior.PlayOneShot (soundsWarrior [nbreSound], 0.7f);
	}

	public override void AttackUp()
	{
		base.AttackUp ();

		weapon.transform.rotation = Quaternion.Euler (0, 0, 0);

		if (fireRate == false) 
		{
			fireRate = true;
			//Instantiate(effect, up.transform.position, arrow.transform.rotation);
			Instantiate(weapon,up.transform.position,weapon.transform.rotation);
			Sound ();
			StartCoroutine (base.WeaponUsed (1f));
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
			Instantiate(weapon,down.transform.position,weapon.transform.rotation);
			Sound ();
			StartCoroutine (base.WeaponUsed (1f));
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
			Instantiate(weapon,right.transform.position,weapon.transform.rotation);
			Sound ();
			StartCoroutine (base.WeaponUsed (1f));
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
			Instantiate(weapon,left.transform.position,weapon.transform.rotation);
			Sound ();
			StartCoroutine (base.WeaponUsed (1f));
		}
	}

	public void LifeStealing()
	{
		base.life.fillAmount = life.fillAmount + 0.0165f;
	}
}