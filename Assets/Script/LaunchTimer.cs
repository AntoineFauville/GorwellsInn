using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaunchTimer : MonoBehaviour
{

    public ChangeMapUnique change;
    public Text timer;
    public float time = 0;
    private System.TimeSpan timeDisplay;
    public bool timing = false;

    public bool gainLife = false;
    public DataBase Salle;
    public Image LifeBar;

    public Animator step;
    public bool easyMode = false;
    public bool hard = false;
    public Animator mode;
    public GameObject difficult;
    public LaunchTimer button;

	private string diff;

    void Start()
    {
        timer.text = string.Format("{0}:{01:00}", timeDisplay.Minutes, timeDisplay.Seconds);
		diff = PlayerPrefs.GetString ("Difficulty");
    }

    void Update()
    {
        step.SetBool("Activate", timing);
        /*mode.SetBool("Easy", easyMode);
        mode.SetBool("Hard", hard);*/

        if (timing == true)
        {
            /*time += Time.deltaTime;
            time = (Mathf.Round(time * 100)) / 100;
            timer.text = string.Format("{0}:{1:00}", (float)time / 60, (float)time % 60);*/
            time += Time.deltaTime;
            timeDisplay = System.TimeSpan.FromSeconds(time);
            timer.text = string.Format("{0}:{01:00}", timeDisplay.Minutes, timeDisplay.Seconds);
        }
    }

    void FixedUpdate()
    {
        if (gainLife == true)
        {
            if (Salle.count == 4 || Salle.count == 8 || Salle.count == 12 || Salle.count == 16)
            {
                gainLife = false;
            }

            else if (Salle.count != 4 || Salle.count != 8 || Salle.count != 12 || Salle.count != 16)
            {
                // La barre gagne de la vie au fur et à mesure du temps;
                gainLife = true;
                LifeBar.fillAmount = LifeBar.fillAmount + 0.00030f; // 0.00045 pour 45 sec.
                // 0.00030f pour 1:07 min. 
            }
        }

        else if (gainLife == false)
        {
            if (Salle.count == 5 || Salle.count == 9 || Salle.count == 13 || Salle.count == 17)
            {
                gainLife = true;
            }
        }
    }

    public void Diminution()
    {
        LifeBar.fillAmount = LifeBar.fillAmount - (float)0.025;
    }

    void OnTriggerEnter(Collider time)
    {
        if (time.gameObject.tag == "Player" )
        {
			if (time.gameObject.tag == "Player" && diff == "Hard")
            {
                //difficult.SetActive(true);
                hard = true;
                mode.SetBool("Hard", true);
            }
			else if (time.gameObject.tag == "Player" && diff == "Easy")
            {
                //difficult.SetActive(true);
                easyMode = true;
                mode.SetBool("Easy", true);
            }

            StartCoroutine(WaitAndLaunch(2));
        }
    }

    IEnumerator WaitAndLaunch(float x)
    {
        yield return new WaitForSeconds(x);
        change.Counter();
        timing = true;
        gainLife = true;
        //difficult.SetActive(false);
    }
}
