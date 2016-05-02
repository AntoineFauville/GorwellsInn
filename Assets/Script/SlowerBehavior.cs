using UnityEngine;
using System.Collections;

public class SlowerBehavior : MonoBehaviour {

    private Vector3 scale ;
    private float x = 0.8f;
    private float y = 0.8f;
    private float z = 0.8f;
	
	// Update is called once per frame
	void Update ()
    {
        x = x + 0.01f;
        z = z + 0.01f;
        scale = new Vector3(x, y, z);
        this.transform.localScale = scale;
    }
}
