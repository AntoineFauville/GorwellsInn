using UnityEngine;
using System.Collections;

public class MakeChoice : MonoBehaviour {

    private int choice1;
    private int choice2;
	public Transform[] jobs = new Transform[3];
    public GameObject[] pictures1;
    public GameObject[] pictures2;
    public GameObject affiche;
    public GameObject parchemin;
    public GameObject parchemin2;
    public ChangeMapUnique count;
    public ChangeMapUnique count2;
    public ChangeClass mineral;
    public ChangeClass mineral2;
	
	public void ChoiceTime ()
    {
		LinkJobs ();

        choice2 = Random.Range(0, 3);
        choice1 = Random.Range(0, 3);

        pictures1[0].SetActive(false);
        pictures1[1].SetActive(false);
        pictures1[2].SetActive(false);
        pictures1[choice1].SetActive(true);
        pictures2[0].SetActive(false);
        pictures2[1].SetActive(false);
        pictures2[2].SetActive(false);
        pictures2[choice2].SetActive(true);
    }

	public void LinkJobs()
	{
		GameObject player = GameObject.Find ("Player");
		Transform sprites = player.transform.Find ("SpriteDuJoueur");
		jobs[0] = sprites.transform.Find ("Guerrier");
		jobs[2] = sprites.transform.Find ("Archer");
		jobs[1] = sprites.transform.Find ("Mage");
	}

    void Update()
    {
        if (affiche.gameObject.activeSelf == true)
        {
            if (mineral.used != true && parchemin.activeSelf == true )
            {
                if (Input.GetButtonUp("BumperRight"))
                {
					jobs[0].gameObject.SetActive(false);
					jobs[1].gameObject.SetActive(false);
					jobs[2].gameObject.SetActive(false);
					PlayerPrefs.SetString ("Classe",jobs [choice1].name);
					jobs[choice1].gameObject.SetActive(true);
                    affiche.SetActive(false);
                    count.Counter();
                    mineral.used = true;
                    //parchemin.SetActive(false);
                }
                else if (Input.GetButtonUp("BumperLeft"))
                {
					jobs[0].gameObject.SetActive(false);
					jobs[1].gameObject.SetActive(false);
					jobs[2].gameObject.SetActive(false);
					PlayerPrefs.SetString ("Classe",jobs [choice2].name);
					jobs[choice2].gameObject.SetActive(true);
                    affiche.SetActive(false);
                    mineral.used = true;
                    count.Counter();
                    //parchemin.SetActive(false);
                }
            }

            else if ( mineral2.used != true && parchemin2.activeSelf == true )
            {
                if (Input.GetButtonUp("BumperRight"))
                {
					jobs[0].gameObject.SetActive(false);
					jobs[1].gameObject.SetActive(false);
					jobs[2].gameObject.SetActive(false);
					PlayerPrefs.SetString ("Classe",jobs [choice1].name);
					jobs[choice1].gameObject.SetActive(true);
                    affiche.SetActive(false);
                    mineral2.used = true;
                    count2.Counter();
                    //parchemin2.SetActive(false);
                }
                else if (Input.GetButtonUp("BumperLeft"))
                {
					jobs[0].gameObject.SetActive(false);
					jobs[1].gameObject.SetActive(false);
					jobs[2].gameObject.SetActive(false);
					PlayerPrefs.SetString ("Classe",jobs [choice2].name);
					jobs[choice2].gameObject.SetActive(true);
                    affiche.SetActive(false);
                    mineral2.used = true;
                    count2.Counter();
                    //parchemin2.SetActive(false);
                }
            }
        }
    }
}
