using UnityEngine;
using System.Collections;

public class ClassChange : MonoBehaviour {

    /* Activation Crystal */
    private Transform choice;
    private GameObject canvas;
    private Transform choiceDisplay;
    private Transform panel1;
    private Transform panel2;
    private bool randLaunch = true;
    private bool used = false;
    private Animator use;
    /**/

    /* Porte */
    private DataBase data;
    private Transform map;
    public int salle;
    private Mapper nbreRoom;
    public ChangeMapUnique count;
    /**/

    /* Choice Time */
    private int nbreChoice1;
    private int nbreChoice2;
    public Transform[] jobs = new Transform[3];
    public Transform[] pics1 = new Transform[3];
    public Transform[] pics2 = new Transform[3];
    /**/

    void Awake()
    {
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }

    void Start ()
    {
        nbreRoom = GameObject.Find("Main Camera").GetComponent<Mapper>();
        salle = data.count;
        canvas = GameObject.Find("Canvas");
        choice = canvas.transform.FindChild("ClassChoicePanel");
        choiceDisplay = choice.transform.FindChild("Choix");
        use = GetComponent<Animator>();

        if(salle != 0)
        {
            map = nbreRoom.mapPoints[salle - 1];
            count = map.Find("Salle/AreaChanging").GetComponent<ChangeMapUnique>();
        }
    }
	
	void Update ()
    {
        use.SetBool("Parchemin", used);

        if (choiceDisplay.gameObject.activeSelf == true)
        {
            if (used != true && this.gameObject.activeSelf == true)
            {
                if (Input.GetButtonUp("BumperRight"))
                {
                    jobs[0].gameObject.SetActive(false);
                    jobs[1].gameObject.SetActive(false);
                    jobs[2].gameObject.SetActive(false);

                    /*pics1[0].gameObject.SetActive(false);
                    pics1[1].gameObject.SetActive(false);
                    pics1[2].gameObject.SetActive(false);

                    pics2[0].gameObject.SetActive(false);
                    pics2[1].gameObject.SetActive(false);
                    pics2[2].gameObject.SetActive(false);*/

                    PlayerPrefs.SetString("Classe", jobs[nbreChoice1].name);
                    jobs[nbreChoice1].gameObject.SetActive(true);
                    choiceDisplay.gameObject.SetActive(false);
                    count.Counter();
                    used = true;
                }
                else if (Input.GetButtonUp("BumperLeft"))
                {
                    jobs[0].gameObject.SetActive(false);
                    jobs[1].gameObject.SetActive(false);
                    jobs[2].gameObject.SetActive(false);

                    /*pics1[0].gameObject.SetActive(false);
                    pics1[1].gameObject.SetActive(false);
                    pics1[2].gameObject.SetActive(false);

                    pics2[0].gameObject.SetActive(false);
                    pics2[1].gameObject.SetActive(false);
                    pics2[2].gameObject.SetActive(false);*/

                    PlayerPrefs.SetString("Classe", jobs[nbreChoice2].name);
                    jobs[nbreChoice2].gameObject.SetActive(true);
                    choiceDisplay.gameObject.SetActive(false);
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
            choiceDisplay.gameObject.SetActive(true);
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
            pics1[i].gameObject.SetActive(false);
            pics2[i].gameObject.SetActive(false);
        }

        pics1[nbreChoice1].gameObject.SetActive(true);
        pics2[nbreChoice2].gameObject.SetActive(true);
    }

    void JobsFinder()
    {
        GameObject player = GameObject.Find("Player");
        Transform sprites = player.transform.Find("SpriteDuJoueur");
        jobs[0] = sprites.transform.Find("Guerrier");
        jobs[2] = sprites.transform.Find("Archer");
        jobs[1] = sprites.transform.Find("Mage");

        // Getting Parent Objects for linking:
        panel1 = choiceDisplay.transform.FindChild("Panel");
        panel2 = choiceDisplay.transform.FindChild("Panel (1)");

        // Linking first choice pictures:
        pics1[0] = panel1.transform.Find("Image (1)");
        pics1[1] = panel1.transform.Find("Image");
        pics1[2] = panel1.transform.Find("Image (2)");

        // Linking second choice pictures:
        pics2[0] = panel2.transform.Find("Image (1)");
        pics2[1] = panel2.transform.Find("Image");
        pics2[2] = panel2.transform.Find("Image (2)");
    }
}
