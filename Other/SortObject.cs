using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortObject : MonoBehaviour {

    [SerializeField]
    private GameObject[] _sortGameObjects;


    public static List<GameObject> sortGameObjects = new List<GameObject> ();

    // Start is called before the first frame update
    void Start () {
        sortGameObjects.Add (gameObject);
    }

    // Update is called once per frame
    void Update () {
        sortGameObjects.Sort (delegate (GameObject j1, GameObject j2) {
            return j1.transform.position.y < j2.transform.position.y ? 1 : -1;
        });
        for (int i = 0; i < sortGameObjects.Count; i++) {
            sortGameObjects[i].GetComponent<SpriteRenderer> ().sortingOrder = i;
        }


        _sortGameObjects = sortGameObjects.ToArray ();
    }


}