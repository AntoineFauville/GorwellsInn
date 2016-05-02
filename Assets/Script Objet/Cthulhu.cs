using UnityEngine;
using System.Collections;

public class Cthulhu : Boss {

	/* Mort */
	public Animator touched;
	public GameObject mort;
	/**/

	public override void Start () 
	{
		base.Start();
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
}
