using UnityEngine;
using System.Collections;

public class ActivationIAUnique : MonoBehaviour {

    // Script permettant d'activer les IA lorsque le joueur arrive dans une salle.

    public GameObject player;
    public GameObject IA;
    public GameObject spawn;

    public Camera cam;
    public DataBase data;
    public int salle;
    public int salleBoss;

    private int compteur;
    private int nbreIA;

    public Mapper camPlace;
    public GameObject beacon;
    public DataBase roomOrder;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
        player = GameObject.Find("Player");
        beacon = GameObject.Find("Beacon");
        camPlace = GameObject.Find("Main Camera").GetComponent<Mapper>();
        roomOrder = this.transform.parent.GetComponent<DataBase>();
        nbreIA = 1;
        IA.SetActive(false);
    }

    void Update()
    {
        if ( data.count != 0 /*salleBoss == 99*/)
        {
            if (cam.transform.position == camPlace.camPoints[data.count - 1].transform.position && beacon.transform.position == camPlace.camPoints[roomOrder.actualRoom].transform.position)
            {
                StartCoroutine(WaitAndGo());
                IA.SetActive(true);
            }
        }
        /*else
        {
            if (cam.transform.position == data.bossMaps[salleBoss - 1].transform.position) (player.transform.position == spawn.transform.position)
            {
                StartCoroutine(WaitAndGo());
                IA.SetActive(true);
            }
        }*/
    }

    IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(1);
    }
}
