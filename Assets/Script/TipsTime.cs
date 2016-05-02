using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TipsTime : MonoBehaviour {

    public string[] tips;
    public Text displayTips;
    private bool change = false;
    private int randTips;
    private int oldtips;

	void Start ()
    {
        randTips = Random.Range(0, tips.Length);
        oldtips = randTips;
        displayTips.text = tips[randTips];
        StartCoroutine(WaitAndChange(5));
	}
	
	void Update ()
    {
        if (change == true)
        {
            change = false;
            randTips = Random.Range(0, tips.Length);

            while (randTips == oldtips)
            {
                randTips = Random.Range(0, tips.Length);
            }

            oldtips = randTips;

            displayTips.text = tips[randTips];

            StartCoroutine(WaitAndChange(5));
        }
	}

    IEnumerator WaitAndChange(int x)
    {
        yield return new WaitForSeconds(x);
        change = true;
    }
}
