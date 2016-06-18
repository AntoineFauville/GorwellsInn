using UnityEngine;
using System.Collections;

public class CthulhuZone : MonoBehaviour {

    public LaunchTimer lifeSupp;
    public float vieTotale;
    public float demiVie;
    private int randTime;
    private int randZone;
    private int randZone2;
    private bool apparition = false;
    private bool already = false;
    public GameObject[] zones;
    public GameObject corpse;

    // Use this for initialization
    void Start ()
    {
        lifeSupp = GameObject.Find("TriggerEasyLaunchGame").GetComponent<LaunchTimer>();
        vieTotale = Mathf.Round(lifeSupp.LifeBar.fillAmount * 20);
        demiVie = vieTotale / 2;
        Zoning();
    }
	
	// Update is called once per frame
	void Update ()
    {
        vieTotale = vieTotale = Mathf.Round(lifeSupp.LifeBar.fillAmount * 20);

        if (vieTotale > demiVie && corpse.gameObject.tag != "Dead")
        {
            if (apparition == true && already == false)
            {
                // activer la flaque et l'animation.
                already = true;
                zones[randZone].SetActive(true);
                StartCoroutine(WaitAndStop());
            }
        }
        else if (vieTotale <= demiVie && corpse.gameObject.tag != "Dead")
        {
            if (apparition == true && already == false)
            {
                // activer les flaques et les animations.
                already = true;
                zones[randZone].SetActive(true);
                zones[randZone2].SetActive(true);
                StartCoroutine(WaitAndStop());
            }
        }
	}

    void Zoning()
    {
        StartCoroutine(WaitAndShot());
    }

    IEnumerator WaitAndShot()
    {
        randZone = Random.Range(0, 3);
        randZone2 = Random.Range(0, 3);

        while(randZone2 == randZone)
        {
            randZone2 = Random.Range(0, 3);
        }
        randTime = Random.Range(5, 8);
        yield return new WaitForSeconds(randTime);
        apparition = true;
    }

    IEnumerator WaitAndStop()
    {
        yield return new WaitForSeconds(5);
        apparition = false;
        already = false;
        zones[randZone].SetActive(false);
        zones[randZone2].SetActive(false);
        Zoning();
    }
}
