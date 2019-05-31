using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAnimation : MonoBehaviour {
    public string trigerName = "Kick";
    public bool kicked = false;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }


    void OnCollisionStay2D (Collision2D other) {
        kicked = true;
        GetComponent<BoxCollider2D> ().isTrigger = true;


        GetComponent<Animator> ().SetTrigger (trigerName);

    }


    public void Dead () {
        Destroy (gameObject);
    }   
}