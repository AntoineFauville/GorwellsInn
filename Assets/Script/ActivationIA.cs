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

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
        player = GameObject.Find("Player");
        for (compteur = 0; compteur < IACount.nbreRand; compteur++)
        {
            IA[compteur].SetActive(false);
        }
    }

	void Update ()
    {

        if (cam.transform.position == data.maps[salle-1].transform.position) /*(player.transform.position == spawn.transform.position)* ancienne méthode de détection */
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

    IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(1);
    }
}
