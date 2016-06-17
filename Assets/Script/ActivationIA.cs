using UnityEngine;
using System.Collections;

public class ActivationIA : MonoBehaviour {

    // Script permettant d'activer les IA lorsque le joueur arrive dans une salle.

    public GameObject player;
    public GameObject[] IA;
    public GameObject spawn;

    public Camera cam;
    public DataBase data;
    public int salle;

    public IATransformActivator IACount;
    public LaunchTimer mode;

    private int compteur;

    public Mapper camPlace;
    public GameObject beacon;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
        player = GameObject.Find("Player");
        mode = GameObject.Find("TriggerEasyLaunchGame").GetComponent<LaunchTimer>();
        beacon = GameObject.Find("Beacon");
        camPlace = GameObject.Find("Main Camera").GetComponent<Mapper>();
        for (compteur = 0; compteur < IACount.nbreRand; compteur++)
        {
            IA[compteur].SetActive(false);
        }
    }

	void Update ()
    {
        if (data.count != 0)
        {
            if (cam.transform.position == camPlace.camPoints[data.count - 1].transform.position && beacon.transform.position == camPlace.camPoints[data.count - 1].transform.position)
            {
                StartCoroutine(WaitAndGo());

                if (mode.easyMode == true)
                {
                    for (compteur = 0; compteur < IACount.nbreEasy; compteur++)
                    {
                        IA[compteur].SetActive(true);
                    }
                }
                else
                {
                    for (compteur = 0; compteur < IACount.nbreRand; compteur++)
                    {
                        IA[compteur].SetActive(true);
                    }
                }
            }
        }
	}

    IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(1);
    }
}
