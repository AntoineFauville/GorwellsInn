using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {
	
	void Update () 
	{

		if ( Input.GetButtonDown("Start"))
			{
			SceneManager.LoadScene ("Menu");
			}
	
	}
}
