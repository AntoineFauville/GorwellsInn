using UnityEngine;
using System.Collections;

public class ClassChange : MonoBehaviour {

    /* Activation Crystal */
    private Transform choice;
    private GameObject canvas;
    private bool randLaunch = true;
    private bool used = false;
    private Animator use;
    /**/

    /* Choice Time */
    private int nbreChoice1;
    private int nbreChoice2;
    private Transform[] jobs = new Transform[3];
    private GameObject[] pics1;
    private GameObject[] pics2;
    private GameObject display;
    public ChangeMapUnique count; 
    /**/

	void Start ()
    {
        canvas = GameObject.Find("Canvas");
        choice = canvas.transform.FindChild("ClassChoicePanel (1)"); 
        use = GetComponent<Animator>();
    }
	
	void Update ()
    {
        use.SetBool("Parchemin", used);

        if (display.gameObject.activeSelf == true)
        {
            if (used != true && this.gameObject.activeSelf == true)
            {
                if (Input.GetButtonUp("BumperRight"))
                {
                    jobs[0].gameObject.SetActive(false);
                    jobs[1].gameObject.SetActive(false);
                    jobs[2].gameObject.SetActive(false);
                    PlayerPrefs.SetString("Classe", jobs[nbreChoice1].name);
                    jobs[nbreChoice1].gameObject.SetActive(true);
                    display.SetActive(false);
                    count.Counter();
                    used = true;
                }
                else if (Input.GetButtonUp("BumperLeft"))
                {
                    jobs[0].gameObject.SetActive(false);
                    jobs[1].gameObject.SetActive(false);
                    jobs[2].gameObject.SetActive(false);
                    PlayerPrefs.SetString("Classe", jobs[nbreChoice2].name);
                    jobs[nbreChoice2].gameObject.SetActive(true);
                    display.SetActive(false);
                    used = true;
                    count.Counter();
                }
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && randLaunch == true)
        {
            randLaunch = false;
            choice.gameObject.SetActive(true);
            ChoiceTime();
        }
    }

    void ChoiceTime()
    {
        print("Ready to Change ??? ");
        JobsFinder();
        nbreChoice1 = Random.Range(0, 3);
        nbreChoice2 = Random.Range(0, 3);

        for (int i=0; i<3; i++)
        {
            pics1[i].SetActive(false);
            pics2[i].SetActive(false);
        }

        pics1[nbreChoice1].SetActive(true);
        pics2[nbreChoice2].SetActive(true);
    }

    void JobsFinder()
    {
        GameObject player = GameObject.Find("Player");
        Transform sprites = player.transform.Find("SpriteDuJoueur");
        jobs[0] = sprites.transform.Find("Guerrier");
        jobs[2] = sprites.transform.Find("Archer");
        jobs[1] = sprites.transform.Find("Mage");

        /* Need a code for linking image to teh choice menu */
    }
}
