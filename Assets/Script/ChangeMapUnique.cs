using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMapUnique : MonoBehaviour {

    public Camera cam;
	private GameObject player;
    public int salle;
    public int salleBoss;
    public int rand = -1;

    public DataBase data;
    public GameObject canvas;
    public Transform gameOver;
    public Text endOfGame;
	int victoryCount;

    public int nbreIA;

    public Animator anim;
    public bool IsDoorOpen;

    public bool NextRoom;

    void Start()
    {
		player = GameObject.Find ("Player");
        nbreIA = 1;
        NextRoom = false;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        data = GameObject.Find("Main Camera").GetComponent<DataBase>();
        canvas = GameObject.Find("Canvas");
        gameOver = canvas.transform.FindChild("GameOverPanel");
        endOfGame = gameOver.transform.FindChild("TextGameOver").GetComponent<Text>();
		victoryCount = PlayerPrefs.GetInt("Victory");
    }

    void Update()
    {
        anim.SetBool("IsDoorOpen", IsDoorOpen);

        if (nbreIA <= 0)
        {
            IsDoorOpen = true;
        }
    }

    public void Counter()
    {
        nbreIA--;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            if (data.count == 12) // Victoire aprés 3 boss ^^
            {
                gameOver.gameObject.SetActive(true);
                endOfGame.text = "Victory";
				victoryCount = victoryCount + 1;
				PlayerPrefs.SetInt ("Victory", victoryCount);
                //Time.timeScale = 0f;
                cam.transform.position = new Vector3(0, 50, 75.6f);
            }

            else if (data.count != 3 && data.count != 7 && data.count != 11 && data.count != 15)
            {
                rand = Random.Range(0, data.taille);

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
                }

                cam.transform.position = data.maps[rand].transform.position;
                player.transform.position = data.playerSpawns[rand].transform.position;
                data.count++;
            }
            else if (data.count == 3 || data.count == 7 || data.count == 11 || data.count == 15)
            {
                rand = Random.Range(0, data.bossTaille);

                while (rand == (salleBoss - 1) || data.previousBossMaps[rand] == true)
                {
                    rand = Random.Range(0, data.bossTaille);
                }

                if (salleBoss != 99)
                {
                    data.previousBossMaps[(salleBoss - 1)] = true;
                }
                else if (salle != 99)
                {
                    data.previousMaps[(salle - 1)] = true;
                }

                cam.transform.position = data.bossMaps[rand].transform.position;
                player.transform.position = data.playerSpawnsBoss[rand].transform.position;
                data.count++;
            }
        }
    }
}
