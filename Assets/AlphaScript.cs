using UnityEngine;
using System.Collections;

public class AlphaScript : MonoBehaviour {

    public GameObject UI;

	// Update is called once per frame
	void Update ()
    {
        if (UI.activeSelf == true)
        {
            if (Input.GetButton("Quit"))
            {
                Application.Quit();
            }
            else if (Input.GetButton("Start"))
            {
                UI.SetActive(false);
            }
        }
        else
        {
            if (Input.GetButton("Quit"))
            {
                UI.SetActive(true);
            }
        }
	}
}
