using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Marksman;
    private int randClass;
    private string previousClasse;
    public GameObject[] images;


    void Start()
    {
        Time.timeScale = 0f;
        previousClasse = PlayerPrefs.GetString("previousClasse");

        if (previousClasse == "Warrior")
        {
            images[0].SetActive(true);
        }
        else if (previousClasse == "Mage")
        {
            images[1].SetActive(true);
        }
        else if (previousClasse == "Marksman")
        {
            images[2].SetActive(true);
        }
        else
        {
            images[3].SetActive(true);
        }
    }

    void Update()
    {

        if (Input.GetButton("BumperLeft"))
        {
           if (previousClasse == "Warrior")
            {
				PlayerPrefs.SetString ("Classe", "Warrior");
                Warrior.SetActive(true);
            }
           else if (previousClasse == "Mage")
            {
				PlayerPrefs.SetString ("Classe", "Mage");
                Mage.SetActive(true);
            }
           else if (previousClasse == "Marksman")
            {
				PlayerPrefs.SetString ("Classe", "Marksman");
                Marksman.SetActive(true);
            }
           else
            {
                randClass = Random.Range(0, 3);

                switch (randClass)
                {
				case 0:
					Warrior.SetActive (true);
					PlayerPrefs.SetString ("Classe", "Warrior");
                    break;

                case 1:
                    Mage.SetActive(true);
					PlayerPrefs.SetString ("Classe", "Mage");
                    break;

                case 2:
                    Marksman.SetActive(true);
					PlayerPrefs.SetString ("Classe", "Marksman");
                    break;
                }
            }

            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }
        else if (Input.GetButton("BumperRight"))
        {
            randClass = Random.Range(0, 3);

            switch (randClass)
            {
                case 0:
                    Warrior.SetActive(true);
				PlayerPrefs.SetString ("Classe", "Warrior");
                    break;

                case 1:
                    Mage.SetActive(true);
				PlayerPrefs.SetString ("Classe", "Mage");
                    break;

                case 2:
                    Marksman.SetActive(true);
				PlayerPrefs.SetString ("Classe", "Marksman");
                    break;
            }

            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }

    }
}
