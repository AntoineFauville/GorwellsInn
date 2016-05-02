using UnityEngine;
using System.Collections;

public class UpDownPlane : MonoBehaviour {

	public ChangeMap countDeath;
	public bool dead = false;


    public void Death()
    {
		if (dead == false) 
		{
			dead = true;
			countDeath.Counter();
		}
    }
}
