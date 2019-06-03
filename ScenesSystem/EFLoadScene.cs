using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EFLoadScene : MonoBehaviour {

    public bool loadScene;
    public string sceneName;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (loadScene) { loadScene = false; LoadScene (sceneName); }
    }


    public void LoadScene (string name) {
        StartCoroutine (LoadYourAsyncScene (name));
    }


    IEnumerator LoadYourAsyncScene (string name) {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}