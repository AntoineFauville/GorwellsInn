using UnityEngine;
using System.Collections;

public class AlphaScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Quit"))
        {
            Application.Quit();
        }
	}
}
