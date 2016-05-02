using UnityEngine;
using System.Collections;

public class DataBase : MonoBehaviour {

    public Transform[] maps;
    public Transform[] playerSpawns;
    public Transform[] bossMaps;
    public Transform[] playerSpawnsBoss;
    public bool[] previousMaps;
    public bool[] previousBossMaps;
    public int taille;
    public int bossTaille;
    public int count;

	/* Patrouilles Statiques */
	public Transform[] salle = new Transform[4];
	/**/

	/* Patrouilles Aléatoires */
	public Transform[] salleAléa = new Transform[11];
	/**/

    void Awake()
    {
        count = 0;
        taille = maps.Length;
        bossTaille = bossMaps.Length;
    }
}
