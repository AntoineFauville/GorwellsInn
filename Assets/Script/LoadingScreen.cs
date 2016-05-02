using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public Texture2D texture;
    static LoadingScreen instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            hide();
            return;
        }

        instance = this;
        gameObject.AddComponent<GUITexture>().enabled = false;
        gameObject.GetComponent<GUITexture>().texture = texture;
        transform.position = new Vector3(0.5f, 0.5f, 1f);
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        if (!Application.isLoadingLevel)
            hide();
    }

    public static void show()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance.gameObject.GetComponent<GUITexture>().enabled = true;
    }

    public static void hide()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance.gameObject.GetComponent<GUITexture>().enabled = false;
    }

    static bool InstanceExists()
    {
        if (!instance)
        {
            return false;
        }
        return true;

    }
}
