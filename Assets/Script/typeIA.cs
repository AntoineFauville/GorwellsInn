using UnityEngine;
using System.Collections;

public class typeIA : MonoBehaviour {

    public GameObject[] IAs ;
    private int rand;

	void Start ()
    {
        rand = Random.Range(0, 6);
        IAs[rand].SetActive(true);
	}
}
