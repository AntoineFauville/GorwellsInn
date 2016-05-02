using UnityEngine;
using System.Collections;

public class IATransformActivator : MonoBehaviour {

    public Transform[] positions;
    public int nbreRand;
    public int nbreEasy;

    void Awake()
    {
        nbreRand = Random.Range(((positions.Length) / 2), (positions.Length) + 1);
        nbreEasy = nbreRand - Mathf.RoundToInt(nbreRand / 3);
    }

	// Use this for initialization
	void Start ()
    {   
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i].gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < nbreRand; i++)
        {
            //positions[i].gameObject.SetActive(true);
        }
	}
}
