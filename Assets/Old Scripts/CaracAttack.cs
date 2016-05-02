using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaracAttack : MonoBehaviour {

    // Script Gérant tout le module d'attaque du joueur.

	public bool use = false;
    private bool FireRate = false;
	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject right;
	public Rigidbody sword;
	public Rigidbody magic;
	public Rigidbody arrow;
    public Rigidbody effect;
    public GameObject Marksman;
	public GameObject Berserker;
	public GameObject Magician;
	public Image ammo;
    private int nbreTir = 0;
	public Personnage player;

    private bool UpAttack = false;
    private bool DownAttack = false;
    private bool RightAttack = false;
    private bool LeftAttack = false;
    public Animator AttackWarrior;
    public Animator AttackArcher;
    public Animator AttackMage;

	private AudioSource playSound;
	public AudioClip[] soundsWarrior;
	public AudioClip[] soundsMarksman;
	public AudioClip[] soundsMage;

	void Start()
	{
		player = GetComponent<Personnage> ();
		playSound = GetComponent<AudioSource>();
	}

    void Update () 
	{
		if (player.dead == true) {
			FireRate = true;
			UpAttack = false;
			DownAttack = false;
			RightAttack = false;
			LeftAttack = false;
		} 
		else 
		{
			
		}

        // Animation des attaques Warrior
        if ( Berserker.activeSelf == true )
        {
            AttackWarrior.SetBool("FlecheHaut", UpAttack);
            AttackWarrior.SetBool("FlecheBas", DownAttack);
            AttackWarrior.SetBool("FlecheDroite", RightAttack);
            AttackWarrior.SetBool("FlecheGauche", LeftAttack);
        }

        // Animation des attaques Archer
        if ( Marksman.activeSelf == true )
        {
            AttackArcher.SetBool("FlecheHaut", UpAttack);
            AttackArcher.SetBool("FlecheBas", DownAttack);
            AttackArcher.SetBool("FlecheDroite", RightAttack);
            AttackArcher.SetBool("FlecheGauche", LeftAttack);
        }

        // Animation des attaques Mage
        if ( Magician.activeSelf == true )
        {
            AttackMage.SetBool("FlecheHaut", UpAttack);
            AttackMage.SetBool("FlecheBas", DownAttack);
            AttackMage.SetBool("FlecheDroite", RightAttack);
            AttackMage.SetBool("FlecheGauche", LeftAttack);
        }

        if ( Input.GetButtonDown("AttackUp") /*&& use == false*/)
		{
			sword.transform.rotation = Quaternion.Euler(0,0,0);
			magic.transform.rotation = Quaternion.Euler(0,0,0);
			arrow.transform.rotation = Quaternion.Euler(0,0,0);

            float randDev = Random.Range(-0.08f, 0.09f);
            Vector3 vectorUp = new Vector3(randDev, 0, 1);
            float randDev2 = Random.Range(-0.08f, 0.09f);
            Vector3 vectorUp2 = new Vector3(randDev2, 0, 1);

            Vector3 pos2 = new Vector3(up.transform.position.x+1, up.transform.position.y, up.transform.position.z);

            UpAttack = true;
            StartCoroutine(EndAttack(0.4f));

            use = true;

            if ( Marksman.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                nbreTir++;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(arrow,up.transform.position,arrow.transform.rotation) as Rigidbody;
				clone.AddForce(vectorUp * 1000 );
				Sound ();

                if (nbreTir == 3)
                {
                    clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
                    clone.AddForce(vectorUp2 * 1000);
                    nbreTir = 0;
                }
                StartCoroutine(WeaponUsed(0.7f));
            }
			else if ( Berserker.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Instantiate(sword,up.transform.position,sword.transform.rotation);
				Sound ();
                StartCoroutine(WeaponUsed(1f));
            }
			else if ( Magician.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(magic,up.transform.position,magic.transform.rotation) as Rigidbody;
				clone.AddForce(up.transform.forward * 650 );
				Sound ();
                StartCoroutine(WeaponUsed(1.2f));
            }
            //use = true;
        }
        else if ( Input.GetButtonDown("AttackDown") /*&& use == false*/)
		{
			sword.transform.rotation = Quaternion.Euler(0,180,0);
			magic.transform.rotation = Quaternion.Euler(0,180,0);
			arrow.transform.rotation = Quaternion.Euler(0,180,0);

            float randDev = Random.Range(-0.08f, 0.09f);
            Vector3 vectorDown = new Vector3(randDev, 0, -1);
            float randDev2 = Random.Range(-0.08f, 0.09f);
            Vector3 vectorDown2 = new Vector3(randDev2, 0, -1);

            Vector3 pos2 = new Vector3(down.transform.position.x + 1, down.transform.position.y, down.transform.position.z);

            DownAttack = true;
            StartCoroutine(EndAttack(0.4f));

            use = true;

            if ( Marksman.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                nbreTir++;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(arrow,down.transform.position,arrow.transform.rotation) as Rigidbody;
				clone.AddForce(vectorDown * 1000);
				Sound ();
                if (nbreTir == 3)
                {
                    clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
                    clone.AddForce(vectorDown2 * 1000);
                    nbreTir = 0;
                }
                StartCoroutine(WeaponUsed(0.7f));
            }
			else if ( Berserker.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Instantiate(sword,down.transform.position,sword.transform.rotation);
				Sound ();
                StartCoroutine(WeaponUsed(1f));
            }
			else if ( Magician.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(magic,down.transform.position,magic.transform.rotation) as Rigidbody;
				clone.AddForce(-down.transform.forward * 650);
				Sound ();
                StartCoroutine(WeaponUsed(1.2f));
            }
            //use = true;
		}
		else if ( Input.GetButtonDown("AttackLeft") /*&& use == false*/)
		{
			sword.transform.rotation = Quaternion.Euler(0,270,0);
			magic.transform.rotation = Quaternion.Euler(0,270,0);
			arrow.transform.rotation = Quaternion.Euler(0,270,0);

            float randDev = Random.Range(-0.08f, 0.09f);
            Vector3 vectorLeft = new Vector3(-1, 0, randDev);
            float randDev2 = Random.Range(-0.08f, 0.09f);
            Vector3 vectorLeft2 = new Vector3(-1, 0, randDev2);

            Vector3 pos2 = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z + 1);

            LeftAttack = true;
            StartCoroutine(EndAttack(0.4f));

            use = true;

            if ( Marksman.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                nbreTir++;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(arrow,left.transform.position,arrow.transform.rotation) as Rigidbody;
				clone.AddForce(vectorLeft * 1000);
				Sound ();
                if (nbreTir == 3)
                {
                    clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
                    clone.AddForce(vectorLeft2 * 1000);
                    nbreTir = 0;
                }

                StartCoroutine(WeaponUsed(0.7f));
            }
			else if ( Berserker.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Instantiate(sword,left.transform.position,sword.transform.rotation);
				Sound ();
                StartCoroutine(WeaponUsed(1f));
            }
			else if ( Magician.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(magic,left.transform.position,magic.transform.rotation) as Rigidbody;
				clone.AddForce(-left.transform.right * 650);
				Sound ();
                StartCoroutine(WeaponUsed(1.2f));
            }
            //use = true;
		}
		else if ( Input.GetButtonDown("AttackRight") /*&& use == false*/)
		{
			sword.transform.rotation = Quaternion.Euler(0,90,0);
			magic.transform.rotation = Quaternion.Euler(0,90,0);
			arrow.transform.rotation = Quaternion.Euler(0,90,0);

            float randDev = Random.Range(-0.08f, 0.09f);
            Vector3 vectorRight = new Vector3(1, 0, randDev);
            float randDev2 = Random.Range(-0.08f, 0.09f);
            Vector3 vectorRight2 = new Vector3(1, 0, randDev2);

            Vector3 pos2 = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z + 1);

            RightAttack = true;
            StartCoroutine(EndAttack(0.4f));

            use = true;

            if ( Marksman.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                nbreTir++;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(arrow,right.transform.position,arrow.transform.rotation) as Rigidbody;
				clone.AddForce(vectorRight * 1000);
				Sound ();
                if (nbreTir ==3)
                {
                    clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
                    clone.AddForce(vectorRight2 * 1000);
                    nbreTir = 0;
                }
                StartCoroutine(WeaponUsed(0.7f));
            }
			else if ( Berserker.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Instantiate(sword,right.transform.position,sword.transform.rotation);
				Sound ();
                StartCoroutine(WeaponUsed(1f));
            }
			else if ( Magician.activeSelf == true && FireRate == false)
			{
                FireRate = true;
                Rigidbody clone;
                Instantiate(effect, up.transform.position, arrow.transform.rotation);
                clone = Instantiate(magic,right.transform.position,magic.transform.rotation) as Rigidbody;
				clone.AddForce(right.transform.right * 650);
				Sound ();
                StartCoroutine(WeaponUsed(1.2f));
            }
		}
	}

	void OnTriggerStay(Collider zone)
	{
		if (zone.gameObject.tag == "Training") 
		{
			// Animation des attaques Warrior
			if ( Berserker.activeSelf == true )
			{
				AttackWarrior.SetBool("FlecheHaut", UpAttack);
				AttackWarrior.SetBool("FlecheBas", DownAttack);
				AttackWarrior.SetBool("FlecheDroite", RightAttack);
				AttackWarrior.SetBool("FlecheGauche", LeftAttack);
			}

			// Animation des attaques Archer
			if ( Marksman.activeSelf == true )
			{
				AttackArcher.SetBool("FlecheHaut", UpAttack);
				AttackArcher.SetBool("FlecheBas", DownAttack);
				AttackArcher.SetBool("FlecheDroite", RightAttack);
				AttackArcher.SetBool("FlecheGauche", LeftAttack);
			}

			// Animation des attaques Mage
			if ( Magician.activeSelf == true )
			{
				AttackMage.SetBool("FlecheHaut", UpAttack);
				AttackMage.SetBool("FlecheBas", DownAttack);
				AttackMage.SetBool("FlecheDroite", RightAttack);
				AttackMage.SetBool("FlecheGauche", LeftAttack);
			}

			if ( Input.GetButtonDown("AttackUp") /*&& use == false*/)
			{
				sword.transform.rotation = Quaternion.Euler(0,0,0);
				magic.transform.rotation = Quaternion.Euler(0,0,0);
				arrow.transform.rotation = Quaternion.Euler(0,0,0);

				float randDev = Random.Range(-0.08f, 0.09f);
				Vector3 vectorUp = new Vector3(randDev, 0, 1);
				float randDev2 = Random.Range(-0.08f, 0.09f);
				Vector3 vectorUp2 = new Vector3(randDev2, 0, 1);

				Vector3 pos2 = new Vector3(up.transform.position.x+1, up.transform.position.y, up.transform.position.z);

				UpAttack = true;
				StartCoroutine(EndAttack(0.4f));

				use = true;

				if ( Marksman.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					nbreTir++;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(arrow,up.transform.position,arrow.transform.rotation) as Rigidbody;
					clone.AddForce(vectorUp * 1000 );

					if (nbreTir == 3)
					{
						clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
						clone.AddForce(vectorUp2 * 1000);
						nbreTir = 0;
					}
					StartCoroutine(WeaponUsed(0.7f));
				}
				else if ( Berserker.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Instantiate(sword,up.transform.position,sword.transform.rotation);
					StartCoroutine(WeaponUsed(1f));
				}
				else if ( Magician.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(magic,up.transform.position,magic.transform.rotation) as Rigidbody;
					clone.AddForce(up.transform.forward * 650 );
					StartCoroutine(WeaponUsed(1.2f));
				}
				//use = true;
			}
			else if ( Input.GetButtonDown("AttackDown") /*&& use == false*/)
			{
				sword.transform.rotation = Quaternion.Euler(0,180,0);
				magic.transform.rotation = Quaternion.Euler(0,180,0);
				arrow.transform.rotation = Quaternion.Euler(0,180,0);

				float randDev = Random.Range(-0.08f, 0.09f);
				Vector3 vectorDown = new Vector3(randDev, 0, -1);
				float randDev2 = Random.Range(-0.08f, 0.09f);
				Vector3 vectorDown2 = new Vector3(randDev2, 0, -1);

				Vector3 pos2 = new Vector3(down.transform.position.x + 1, down.transform.position.y, down.transform.position.z);

				DownAttack = true;
				StartCoroutine(EndAttack(0.4f));

				use = true;

				if ( Marksman.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					nbreTir++;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(arrow,down.transform.position,arrow.transform.rotation) as Rigidbody;
					clone.AddForce(vectorDown * 1000);
					if (nbreTir == 3)
					{
						clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
						clone.AddForce(vectorDown2 * 1000);
						nbreTir = 0;
					}
					StartCoroutine(WeaponUsed(0.7f));
				}
				else if ( Berserker.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Instantiate(sword,down.transform.position,sword.transform.rotation);
					StartCoroutine(WeaponUsed(1f));
				}
				else if ( Magician.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(magic,down.transform.position,magic.transform.rotation) as Rigidbody;
					clone.AddForce(-down.transform.forward * 650);
					StartCoroutine(WeaponUsed(1.2f));
				}
				//use = true;
			}
			else if ( Input.GetButtonDown("AttackLeft") /*&& use == false*/)
			{
				sword.transform.rotation = Quaternion.Euler(0,270,0);
				magic.transform.rotation = Quaternion.Euler(0,270,0);
				arrow.transform.rotation = Quaternion.Euler(0,270,0);

				float randDev = Random.Range(-0.08f, 0.09f);
				Vector3 vectorLeft = new Vector3(-1, 0, randDev);
				float randDev2 = Random.Range(-0.08f, 0.09f);
				Vector3 vectorLeft2 = new Vector3(-1, 0, randDev2);

				Vector3 pos2 = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z + 1);

				LeftAttack = true;
				StartCoroutine(EndAttack(0.4f));

				use = true;

				if ( Marksman.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					nbreTir++;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(arrow,left.transform.position,arrow.transform.rotation) as Rigidbody;
					clone.AddForce(vectorLeft * 1000);
					if (nbreTir == 3)
					{
						clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
						clone.AddForce(vectorLeft2 * 1000);
						nbreTir = 0;
					}

					StartCoroutine(WeaponUsed(0.7f));
				}
				else if ( Berserker.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Instantiate(sword,left.transform.position,sword.transform.rotation);
					StartCoroutine(WeaponUsed(1f));
				}
				else if ( Magician.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(magic,left.transform.position,magic.transform.rotation) as Rigidbody;
					clone.AddForce(-left.transform.right * 650);
					StartCoroutine(WeaponUsed(1.2f));
				}
				//use = true;
			}
			else if ( Input.GetButtonDown("AttackRight") /*&& use == false*/)
			{
				sword.transform.rotation = Quaternion.Euler(0,90,0);
				magic.transform.rotation = Quaternion.Euler(0,90,0);
				arrow.transform.rotation = Quaternion.Euler(0,90,0);

				float randDev = Random.Range(-0.08f, 0.09f);
				Vector3 vectorRight = new Vector3(1, 0, randDev);
				float randDev2 = Random.Range(-0.08f, 0.09f);
				Vector3 vectorRight2 = new Vector3(1, 0, randDev2);

				Vector3 pos2 = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z + 1);

				RightAttack = true;
				StartCoroutine(EndAttack(0.4f));

				use = true;

				if ( Marksman.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					nbreTir++;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(arrow,right.transform.position,arrow.transform.rotation) as Rigidbody;
					clone.AddForce(vectorRight * 1000);
					if (nbreTir ==3)
					{
						clone = Instantiate(arrow, pos2, arrow.transform.rotation) as Rigidbody;
						clone.AddForce(vectorRight2 * 1000);
						nbreTir = 0;
					}
					StartCoroutine(WeaponUsed(0.7f));
				}
				else if ( Berserker.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Instantiate(sword,right.transform.position,sword.transform.rotation);
					StartCoroutine(WeaponUsed(1f));
				}
				else if ( Magician.activeSelf == true && FireRate == false)
				{
					FireRate = true;
					Rigidbody clone;
					Instantiate(effect, up.transform.position, arrow.transform.rotation);
					clone = Instantiate(magic,right.transform.position,magic.transform.rotation) as Rigidbody;
					clone.AddForce(right.transform.right * 650);
					StartCoroutine(WeaponUsed(1.2f));
				}
			}
		}
	}

	void Sound()
	{
		int nbreSound = Random.Range (0, 3);

		if (Magician.activeSelf == true) 
		{
			playSound.PlayOneShot (soundsMage [nbreSound], 0.7f);
		} 
		else if (Berserker.activeSelf == true) 
		{
			playSound.PlayOneShot (soundsWarrior [nbreSound], 0.7f);
		} 
		else if (Marksman.activeSelf == true) 
		{
			playSound.PlayOneShot (soundsMarksman [nbreSound], 0.7f);
		}
	}

    IEnumerator WeaponUsed(float x)
	{
		// Coroutine empechant le joueur d'attaquer plus d'une fois toutes les x secondes.
		yield return new WaitForSeconds(x);
		use = false;
        FireRate = false;
	}

    IEnumerator EndAttack(float x)
    {
        yield return new WaitForSeconds(x);
        UpAttack = false;
        DownAttack = false;
        RightAttack = false;
        LeftAttack = false;
    }
}
