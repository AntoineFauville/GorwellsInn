using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public LaunchTimer time;
    public LaunchTimer timeEasy;
    public DataBase level;
    public Text timePlayer;
    public Text levelPlayer;
    public Text classPlayer;

    string difficult;
    private int nbreDeath;

    public GameObject Mage;
    public GameObject Archer;
    public GameObject Warrior;

	// Use this for initialization
	void Start ()
    {
        time.timing = false;
        timePlayer.text = time.timer.text;
        levelPlayer.text = level.count.ToString();

        if (Mage.activeSelf == true)
        {
            classPlayer.text = "Mage";
        }
        else if (Archer.activeSelf == true)
        {
            classPlayer.text = "Marksman";
        }
        else if (Warrior.activeSelf == true)
        {
            classPlayer.text = "Warrior";
        }

		classPlayer.text = PlayerPrefs.GetString ("Classe");

        PlayerPrefs.SetString("previousClasse", classPlayer.text);

        // Comptabilise le nombre de morts du Joueur.
        nbreDeath = PlayerPrefs.GetInt("Death");
        nbreDeath = nbreDeath + 1;
        PlayerPrefs.SetInt("Death", nbreDeath);

		float timeTotal = PlayerPrefs.GetFloat ("DungeonTime");
		timeTotal = time.time + timeTotal;
		PlayerPrefs.SetFloat ("DungeonTime", timeTotal);

		PlayerPrefs.SetString("Tuto","False");

        Scoring();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Start"))
        {
            //Application.LoadLevel("Main Scene");
			SceneManager.LoadScene ("Menu");
        }
	}

    public void Scoring()
    {
        float finalScore = 0;
        float score1 = PlayerPrefs.GetFloat("Score1");
        float score2 = PlayerPrefs.GetFloat("Score2");
        float score3 = PlayerPrefs.GetFloat("Score3");
        float score4 = PlayerPrefs.GetFloat("Score4");
        float score5 = PlayerPrefs.GetFloat("Score5");
        int salleGame = level.count;
        int salleScore1 = PlayerPrefs.GetInt("NumSalle1");
        int salleScore2 = PlayerPrefs.GetInt("NumSalle2");
        int salleScore3 = PlayerPrefs.GetInt("NumSalle3");
        int salleScore4 = PlayerPrefs.GetInt("NumSalle4");
        int salleScore5 = PlayerPrefs.GetInt("NumSalle5");
        float timeGame = time.time;
        float timeScore1 = PlayerPrefs.GetFloat("Time1");
        float timeScore2 = PlayerPrefs.GetFloat("Time2");
        float timeScore3 = PlayerPrefs.GetFloat("Time3");
        float timeScore4 = PlayerPrefs.GetFloat("Time4");
        float timeScore5 = PlayerPrefs.GetFloat("Time5");
        string classeGame = classPlayer.text;
        string classeScore1 = PlayerPrefs.GetString("Classe1");
        string classeScore2 = PlayerPrefs.GetString("Classe2");
        string classeScore3 = PlayerPrefs.GetString("Classe3");
        string classeScore4 = PlayerPrefs.GetString("Classe4");
        string classeScore5 = PlayerPrefs.GetString("Classe5");
        if (time.hard == true)
        {
            difficult = "Hard";
			timeGame = timeEasy.time;
        }
        else if (timeEasy.easyMode == true)
        {
            difficult = "Easy";
            timeGame = timeEasy.time;
        }
        string difficult1 = PlayerPrefs.GetString("Mode1");
        string difficult2 = PlayerPrefs.GetString("Mode2");
        string difficult3 = PlayerPrefs.GetString("Mode3");
        string difficult4 = PlayerPrefs.GetString("Mode4");
        string difficult5 = PlayerPrefs.GetString("Mode5");

        /* Calcul du Score*/

        if (salleGame == 12)
        {
            finalScore = (1 / timeGame) * 10000;

            if (difficult == "Hard")
            {
                finalScore = finalScore * 2;
            }
        }
        /**/

        if (finalScore > score1 || salleGame > salleScore1 || salleGame == salleScore1 && timeGame < timeScore1)
        {
            // l'ancien score devient le second et ainsi de suite
            /*2*/
            PlayerPrefs.SetFloat("Score2", score1);
            PlayerPrefs.SetInt("NumSalle2", salleScore1);
            PlayerPrefs.SetString("Classe2", classeScore1);
            PlayerPrefs.SetFloat("Time2", timeScore1);
            PlayerPrefs.SetString("Mode2", difficult1);
            /*3*/
            PlayerPrefs.SetFloat("Score3", score2);
            PlayerPrefs.SetInt("NumSalle3", salleScore2);
            PlayerPrefs.SetString("Classe3", classeScore2);
            PlayerPrefs.SetFloat("Time3", timeScore2);
            PlayerPrefs.SetString("Mode3", difficult2);
            /*4*/
            PlayerPrefs.SetFloat("Score4", score3);
            PlayerPrefs.SetInt("NumSalle4", salleScore3);
            PlayerPrefs.SetString("Classe4", classeScore3);
            PlayerPrefs.SetFloat("Time4", timeScore3);
            PlayerPrefs.SetString("Mode4", difficult3);
            /*5*/
            PlayerPrefs.SetFloat("Score5", score4);
            PlayerPrefs.SetInt("NumSalle5", salleScore4);
            PlayerPrefs.SetString("Classe5", classeScore4);
            PlayerPrefs.SetFloat("Time5", timeScore4);
            PlayerPrefs.SetString("Mode5", difficult4);

            // Deviens le Score n°1
            PlayerPrefs.SetFloat("Score1", finalScore);
            PlayerPrefs.SetInt("NumSalle1", salleGame);
            PlayerPrefs.SetString("Classe1", classeGame);
            PlayerPrefs.SetFloat("Time1", timeGame);
            PlayerPrefs.SetString("Mode1", difficult);
        }
        else if (finalScore > score2 || salleGame > salleScore2 || salleGame == salleScore1 && timeGame < timeScore2)
        {
            // l'ancien score devient le second et ainsi de suite
            /*3*/
            PlayerPrefs.SetFloat("Score3", score2);
            PlayerPrefs.SetInt("NumSalle3", salleScore2);
            PlayerPrefs.SetString("Classe3", classeScore2);
            PlayerPrefs.SetFloat("Time3", timeScore2);
            PlayerPrefs.SetString("Mode3", difficult2);
            /*4*/
            PlayerPrefs.SetFloat("Score4", score3);
            PlayerPrefs.SetInt("NumSalle4", salleScore3);
            PlayerPrefs.SetString("Classe4", classeScore3);
            PlayerPrefs.SetFloat("Time4", timeScore3);
            PlayerPrefs.SetString("Mode4", difficult3);
            /*5*/
            PlayerPrefs.SetFloat("Score5", score4);
            PlayerPrefs.SetInt("NumSalle5", salleScore4);
            PlayerPrefs.SetString("Classe5", classeScore4);
            PlayerPrefs.SetFloat("Time5", timeScore4);
            PlayerPrefs.SetString("Mode5", difficult4);

            //Deviens le Score n° 2
            PlayerPrefs.SetFloat("Score2", finalScore);
            PlayerPrefs.SetInt("NumSalle2", salleGame);
            PlayerPrefs.SetString("Classe2", classeGame);
            PlayerPrefs.SetFloat("Time2", timeGame);
            PlayerPrefs.SetString("Mode2", difficult);
        }
        else if (finalScore > score3 || salleGame > salleScore3 || salleGame == salleScore1 && timeGame < timeScore3)
        {
            // l'ancien score devient le second et ainsi de suite
            /*4*/
            PlayerPrefs.SetFloat("Score4", score3);
            PlayerPrefs.SetInt("NumSalle4", salleScore3);
            PlayerPrefs.SetString("Classe4", classeScore3);
            PlayerPrefs.SetFloat("Time4", timeScore3);
            PlayerPrefs.SetString("Mode4", difficult3);
            /*5*/
            PlayerPrefs.SetFloat("Score5", score4);
            PlayerPrefs.SetInt("NumSalle5", salleScore4);
            PlayerPrefs.SetString("Classe5", classeScore4);
            PlayerPrefs.SetFloat("Time5", timeScore4);
            PlayerPrefs.SetString("Mode5", difficult4);

            //Deviens le Score n° 3
            PlayerPrefs.SetFloat("Score3", finalScore);
            PlayerPrefs.SetInt("NumSalle3", salleGame);
            PlayerPrefs.SetString("Classe3", classeGame);
            PlayerPrefs.SetFloat("Time3", timeGame);
            PlayerPrefs.SetString("Mode3", difficult);
        }
        else if (finalScore > score4 || salleGame > salleScore4 || salleGame == salleScore1 && timeGame < timeScore4)
        {
            // l'ancien score devient le second et ainsi de suite
            /*5*/
            PlayerPrefs.SetFloat("Score5", score4);
            PlayerPrefs.SetInt("NumSalle5", salleScore4);
            PlayerPrefs.SetString("Classe5", classeScore4);
            PlayerPrefs.SetFloat("Time5", timeScore4);
            PlayerPrefs.SetString("Mode5", difficult4);

            //Deviens le Score n° 4
            PlayerPrefs.SetFloat("Score4", finalScore);
            PlayerPrefs.SetInt("NumSalle4", salleGame);
            PlayerPrefs.SetString("Classe4", classeGame);
            PlayerPrefs.SetFloat("Time4", timeGame);
            PlayerPrefs.SetString("Mode4", difficult);
        }
        else if (finalScore > score5 || salleGame > salleScore5 || salleGame == salleScore1 && timeGame < timeScore5)
        {
            //Deviens le Score n° 5
            PlayerPrefs.SetFloat("Score5", finalScore);
            PlayerPrefs.SetInt("NumSalle5", salleGame);
            PlayerPrefs.SetString("Classe5", classeGame);
            PlayerPrefs.SetFloat("Time5", timeGame);
            PlayerPrefs.SetString("Mode5", difficult);
        }

    }
}
