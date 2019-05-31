    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FSCollisionFocus : MonoBehaviour {
    public GameObject triggerObject;


    void Start () {

    }

    void Update () {

    }

    private void OnCollisionEnter2D (Collision2D other) {

        if (IsTarget (other.collider) & this.enabled) FS_Manager.AddFocus (gameObject);


    }
    private void OnCollisionExit2D (Collision2D other) {

        if (IsTarget (other.collider) & this.enabled) FS_Manager.RemoveFocus (gameObject);

    }
    private void OnCollisionStay2D (Collision2D other) {

        // if (IsTarget (other.collider) & this.enabled) onCollision.stay.Invoke ();

    }
    private void OnTriggerEnter2D (Collider2D other) {
       //   if (IsTarget (other) & this.enabled) FSInputSender.AddFocus (gameObject);
    }
    private void OnTriggerExit2D (Collider2D other) {
       //   if (IsTarget (other) & this.enabled) FSInputSender.RemoveFocus (gameObject);
    }
    private void OnTriggerStay2D (Collider2D other) {
        // if (IsTarget (other) & this.enabled) onTrigger.stay.Invoke ();
    }


    private bool IsTarget (Collider2D other) {
        return other.gameObject == triggerObject;
    }


}