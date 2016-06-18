using UnityEngine;
using System.Collections;

public class ChangeMap : MonoBehaviour {

    public Camera cam;
	public GameObject player;
    public int salle;
    public int salleBoss;
	public int rand = -1;

    public DataBase data;

	public int nbreIA;
	private int nbreKilled;
    public IATransformActivator nbreEnemy;

    public Animator anim;
    public bool IsDoorOpen;

    public bool NextRoom;

    public LaunchTimer mode;
    private bool easy = false;

    private Mapper playerSpawn;
    private Transform spawnPlace;
    private GameObject beacon;

    void Start ()
	{
		player = GameObject.Find ("Player");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
        mode = GameObject.Find("TriggerEasyLaunchGame").GetComponent<LaunchTimer>();
        beacon = GameObject.Find("Beacon");
        playerSpawn = GameObject.Find("Main Camera").GetComponent<Mapper>();
        nbreIA = nbreEnemy.nbreRand;
        NextRoom = false;
	}

	void Update()
	{
        anim.SetBool("IsDoorOpen", IsDoorOpen);

        if (mode.easyMode == true && easy == false )
        {
            nbreIA = nbreEnemy.nbreEasy;
            easy = true;
        }

        if (nbreIA <= 0) 
		{
            IsDoorOpen = true;
		}
	}

	public void Counter()
	{
		nbreIA--;
		nbreKilled = PlayerPrefs.GetInt ("Ennemy");
		nbreKilled = nbreKilled + 1;
		PlayerPrefs.SetInt ("Ennemy", nbreKilled);
	}

	void OnTriggerEnter(Collider coll)
	{
        if ( coll.gameObject.tag == "Player")
        {

            if (data.count != 3 && data.count != 7 && data.count != 11 && data.count != 15)
            {
                /*rand = Random.Range(0, data.taille);

                while (rand == (salle - 1) || data.previousMaps[rand] == true)
                {
                    rand = Random.Range(0, data.taille);
                }

                data.ChangeNumberRoom(rand + 1);

                if (salle != 99)
                {
                    data.previousMaps[(salle - 1)] = true;
                }
                else if (salleBoss != 99)
                {
                    data.previousBossMaps[(salleBoss - 1)] = true;
                }*/

                spawnPlace = playerSpawn.mapPoints[data.count];

                cam.transform.position = playerSpawn.camPoints[data.count].transform.position /*data.maps[rand].transform.position*/;
                beacon.transform.position = playerSpawn.camPoints[data.count].transform.position;
                player.transform.position = spawnPlace.Find("Salle/SpawnPlayer").transform.position /*data.playerSpawns[rand].transform.position*/;
                data.count++;
            }
            else if ( data.count == 3 || data.count == 7 || data.count == 11 || data.count == 15)
            {
                /*rand = Random.Range(0, data.bossTaille);

                while (rand == (salleBoss - 1) || data.previousBossMaps[rand] == true)
                {
                    rand = Random.Range(0, data.bossTaille);
                }

                if ( salleBoss != 99)
                {
                    data.previousBossMaps[(salleBoss - 1)] = true;
                }
                else if (salle != 99)
                {
                    data.previousMaps[(salle - 1)] = true;
                }*/

                spawnPlace = playerSpawn.mapPoints[data.count];

                cam.transform.position = playerSpawn.camPoints[data.count].transform.position;
                beacon.transform.position = playerSpawn.camPoints[data.count].transform.position;
                player.transform.position = spawnPlace.Find("Salle/SpawnPlayer").transform.position;
                data.count++;
            }
        }
	}
}
