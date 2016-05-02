using UnityEngine;
using System.Collections;

public class OwlClock : MonoBehaviour {

    public Transform spawn;
    public Transform[] Hours;
    public Rigidbody featherTime;
    public GameObject corpse;
    private int i = 0;
    private bool timePassing = false;
    private bool shot = false;
	
    void Start()
    {
        StartCoroutine(WaitAndClockTime());
    }

	// Update is called once per frame
	void Update ()
    {
        if (corpse.tag == "Dead")
        {
            this.enabled = false;
        }

	    if ( timePassing == true && shot == false && corpse.tag != "Dead")
        {
            shot = true;

            /*for (int i = 0; i < Hours.Length; i++)
            {
                Rigidbody feather;
                StartCoroutine(WaitAndNextHour());
                feather = Instantiate(featherTime, spawn.position, spawn.rotation) as Rigidbody;

                feather.velocity = (Hours[i].position - transform.position).normalized * 12;
            }*/

                Rigidbody feather;
                feather = Instantiate(featherTime, spawn.position, spawn.rotation) as Rigidbody;

                feather.velocity = (Hours[i].position - transform.position).normalized * 12;

                StartCoroutine(WaitAndNextHour());
                i++;

            if (i == 12)
            {
                i = 0;
            }

            StartCoroutine(WaitAndClockTime());
        }
	}

    IEnumerator WaitAndClockTime()
    {
        yield return new WaitForSeconds(4);
        timePassing = true;
        shot = false;
    }

    IEnumerator WaitAndNextHour()
    {
        yield return new WaitForSeconds(0.5f);
        shot = false;
    }
}
