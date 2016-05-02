using UnityEngine;
using System.Collections;

public class LazerShot : MonoBehaviour {

    public Animator LaserOn;
    private bool laser1;
    private bool laser2;
    private bool laser3;
    private bool laser4;
    private bool laserPrepa;

    private bool shoot;
    private int randLaser;

	private AudioSource playSound;
	public AudioClip lazer;

	void Start ()
    {
		playSound = GetComponent<AudioSource>();

        randLaser = Random.Range(0,4);
		shoot = false;
		StartCoroutine(Lazzer());

        if (randLaser == 0)
        {
            laser1 = true;
			laser2 = false;
			laser3 = false;
			laser4 = false;
        }
        else if (randLaser == 1)
        {
			laser1 = false;
			laser2 = true;
			laser3 = false;
			laser4 = false;
        }
        else if (randLaser == 2)
        {
			laser1 = false;
			laser2 = false;
			laser3 = true;
			laser4 = false;
        }
        else if (randLaser == 3)
        {
			laser1 = false;
			laser2 = false;
			laser3 = false;
			laser4 = true;
        }
	}
	

	void Update ()
    {
        if ( this.gameObject.tag != "Dead")
        {
            LaserOn.SetBool("LazzerOn", laserPrepa);
            LaserOn.SetBool("Lazer1", laser1);
            LaserOn.SetBool("Lazer2", laser2);
            LaserOn.SetBool("Lazer3", laser3);
            LaserOn.SetBool("Lazer4", laser4);
        }
		
		if (shoot == true && this.gameObject.tag != "Dead")
		{
			shoot = false;
            Fire();
		}
		
        if (this.gameObject.tag =="Dead")
        {
            LaserOn.Stop();
            LaserOn.gameObject.SetActive(false);
        }
    }
	
	public void Fire()
	{
		randLaser = Random.Range(0,4);

        if (randLaser == 0)
        {
            laser1 = true;
			laser2 = false;
			laser3 = false;
			laser4 = false;
        }
        else if (randLaser == 1)
        {
			laser1 = false;
			laser2 = true;
			laser3 = false;
			laser4 = false;
        }
        else if (randLaser == 2)
        {
			laser1 = false;
			laser2 = false;
			laser3 = true;
			laser4 = false;
        }
        else if (randLaser == 3)
        {
			laser1 = false;
			laser2 = false;
			laser3 = false;
			laser4 = true;
        }

        StartCoroutine(PrepaLazer());
		playSound.PlayOneShot (lazer, 1.0f);
        StartCoroutine(Lazzer());
	}
	
	IEnumerator Lazzer()
	{
		yield return new WaitForSeconds(4);
		shoot = true;
    }
	
	IEnumerator PrepaLazer()
	{
		laserPrepa = true;
        yield return new WaitForSeconds(3);
		laserPrepa = false;
    }
	
}
