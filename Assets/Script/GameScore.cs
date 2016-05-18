using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

    public Text P1;
    public Text P2;
    public Text P3;
    public Text P4;
    public Text P5;

    // Les différents scores à afficher
    private float score1;
    private int numSalle1;
    private float timer1;
    private string classe1;
    private string difficult1;
    private float score2;
    private int numSalle2;
    private float timer2;
    private string classe2;
    private string difficult2;
    private float score3;
    private int numSalle3;
    private float timer3;
    private string classe3;
    private string difficult3;
    private float score4;
    private int numSalle4;
    private float timer4;
    private string classe4;
    private string difficult4;
    private float score5;
    private int numSalle5;
    private float timer5;
    private string classe5;
    private string difficult5;

    private System.TimeSpan timeDisplay1;
    private System.TimeSpan timeDisplay2;
    private System.TimeSpan timeDisplay3;
    private System.TimeSpan timeDisplay4;
    private System.TimeSpan timeDisplay5;

    // Use this for initialization
    void Start ()
    {
        // Load Scores registered
        score1 = PlayerPrefs.GetFloat("Score1");
        numSalle1 = PlayerPrefs.GetInt("NumSalle1");
        timer1 = PlayerPrefs.GetFloat("Time1");
        classe1 = PlayerPrefs.GetString("Classe1");
        difficult1 = PlayerPrefs.GetString("Mode1");

        score2 = PlayerPrefs.GetFloat("Score2");
        numSalle2 = PlayerPrefs.GetInt("NumSalle2");
        timer2 = PlayerPrefs.GetFloat("Time2");
        classe2 = PlayerPrefs.GetString("Classe2");
        difficult2 = PlayerPrefs.GetString("Mode2");

        score3 = PlayerPrefs.GetFloat("Score3");
        numSalle3 = PlayerPrefs.GetInt("NumSalle3");
        timer3 = PlayerPrefs.GetFloat("Time3");
        classe3 = PlayerPrefs.GetString("Classe3");
        difficult3 = PlayerPrefs.GetString("Mode3");

        score4 = PlayerPrefs.GetFloat("Score4");
        numSalle4 = PlayerPrefs.GetInt("NumSalle4");
        timer4 = PlayerPrefs.GetFloat("Time4");
        classe4 = PlayerPrefs.GetString("Classe4");
        difficult4 = PlayerPrefs.GetString("Mode4");

        score5 = PlayerPrefs.GetFloat("Score5");
        numSalle5 = PlayerPrefs.GetInt("NumSalle5");
        timer5 = PlayerPrefs.GetFloat("Time5");
        classe5 = PlayerPrefs.GetString("Classe5");
        difficult5 = PlayerPrefs.GetString("Mode5");

        timeDisplay1 = System.TimeSpan.FromSeconds(timer1);
        timeDisplay2 = System.TimeSpan.FromSeconds(timer2);
        timeDisplay3 = System.TimeSpan.FromSeconds(timer3);
        timeDisplay4 = System.TimeSpan.FromSeconds(timer4);
        timeDisplay5 = System.TimeSpan.FromSeconds(timer5);

        P1.text = score1 + "          " + numSalle1 + "              " + string.Format("{0}:{01:00}", timeDisplay1.Minutes, timeDisplay1.Seconds) + "           " + classe1 + "           " + difficult1;

		P2.text = score2 + "          " + numSalle2 + "              " + string.Format("{0}:{01:00}", timeDisplay2.Minutes, timeDisplay2.Seconds) + "           " + classe2 + "           " + difficult2;

		P3.text = score3 + "          " + numSalle3 + "              " + string.Format("{0}:{01:00}", timeDisplay3.Minutes, timeDisplay3.Seconds) + "           " + classe3 + "           " + difficult3;

		P4.text = score4 + "          " + numSalle4 + "              " + string.Format("{0}:{01:00}", timeDisplay4.Minutes, timeDisplay4.Seconds) + "           " + classe4 + "           " + difficult4;

		P5.text = score5 + "          " + numSalle5 + "              " + string.Format("{0}:{01:00}", timeDisplay5.Minutes, timeDisplay5.Seconds) + "           " + classe5 + "           " + difficult5;
    }

    void Reset ()
    {
        PlayerPrefs.SetInt("NumSalle2", 0);
        PlayerPrefs.SetString("Classe2", "");
        PlayerPrefs.SetFloat("Time2", 0);
        PlayerPrefs.SetString("Mode2", "");
        /*3*/
        PlayerPrefs.SetInt("NumSalle3", 0);
        PlayerPrefs.SetString("Classe3", "");
        PlayerPrefs.SetFloat("Time3", 0);
        PlayerPrefs.SetString("Mode3", "");
        /*4*/
        PlayerPrefs.SetInt("NumSalle4", 0);
        PlayerPrefs.SetString("Classe4", "");
        PlayerPrefs.SetFloat("Time4", 0);
        PlayerPrefs.SetString("Mode4", "");
        /*5*/
        PlayerPrefs.SetInt("NumSalle5", 0);
        PlayerPrefs.SetString("Classe5", "");
        PlayerPrefs.SetFloat("Time5", 0);
        PlayerPrefs.SetString("Mode5", "");

        // Deviens le Score n°1
        PlayerPrefs.SetInt("NumSalle1", 0);
        PlayerPrefs.SetString("Classe1", "");
        PlayerPrefs.SetFloat("Time1", 0);
        PlayerPrefs.SetString("Mode1", "");

        print("Reset Scores");

        //Start();
    }
}
