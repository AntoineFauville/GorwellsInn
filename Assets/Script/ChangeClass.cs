using UnityEngine;
using System.Collections;

public class ChangeClass : MonoBehaviour {

    public Transform choice;
    public GameObject canvas;
    public MakeChoice go;
    private bool randLaunch = true;
    public bool used = false;
    public Animator use;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        choice = canvas.transform.FindChild("ClassChoicePanel (1)");
        go = GameObject.Find("Main Camera").GetComponent<MakeChoice>();
    }

    void Update()
    {
        use.SetBool("Parchemin", used);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && randLaunch == true)
        {
            randLaunch = false;
            choice.gameObject.SetActive(true);
            go.ChoiceTime();
        }
    }
}
