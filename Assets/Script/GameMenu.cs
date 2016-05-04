using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	private AudioSource sound;
	public AudioClip soundChoice;

	void Start()
	{
		sound = GetComponent<AudioSource> ();
	}

    void Update()
    {
		// Passer l'information de la difficulté d'une scéne à l'autre.

		if (Input.GetButtonDown ("AttackUp") || Input.GetKey ("y")) 
		{
			// Mode Easy
			PlayerPrefs.SetString("Difficulty","Easy");
			sound.PlayOneShot (soundChoice, 1.0f);
			Play ();
		}

		if (Input.GetButtonDown ("AttackLeft") || Input.GetKey ("x")) 
		{
			// Mode Hard
			PlayerPrefs.SetString("Difficulty","Hard");
			sound.PlayOneShot (soundChoice, 1.0f);
			Play ();
		}
    }

    // Bouton pour lancer la partie.
    public void Play()
    {
        LoadingScreen.show();// Loading Screen
        //Application.LoadLevel("Main Scene"); DEPRECEATED
		SceneManager.LoadScene ("Main Scene"); 
    }
}
