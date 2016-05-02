using UnityEngine;
using System.Collections;

public class ChangeClass : MonoBehaviour {

    public GameObject Choice;
    public MakeChoice go;
    private bool randLaunch = true;
    public bool used = false;
    public Animator use;

    void Update()
    {
        use.SetBool("Parchemin", used);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && randLaunch == true)
        {
            randLaunch = false;
            Choice.SetActive(true);
            go.ChoiceTime();
        }
    }
}
