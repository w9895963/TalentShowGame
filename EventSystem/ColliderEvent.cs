using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour {
    public GameObject triggerObject;
    public OnCollision onCollision;
    public OnCollision onTrigger;

    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnCollisionEnter2D (Collision2D other) {

        if (IsTarget (other.collider)& this.enabled) onCollision.enter.Invoke ();


    }
    private void OnCollisionExit2D (Collision2D other) {

        if (IsTarget (other.collider)& this.enabled) onCollision.exit.Invoke ();

    }
    private void OnCollisionStay2D (Collision2D other) {

        if (IsTarget (other.collider)& this.enabled) onCollision.stay.Invoke ();

    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (IsTarget (other)& this.enabled) onTrigger.enter.Invoke ();
    }
    private void OnTriggerExit2D (Collider2D other) {
        if (IsTarget (other)& this.enabled) onTrigger.exit.Invoke ();
    }
    private void OnTriggerStay2D (Collider2D other) {
        if (IsTarget (other)& this.enabled) onTrigger.stay.Invoke ();
    }


    private bool IsTarget (Collider2D other) {
        return other.gameObject == triggerObject;
    }

    [Serializable]
    public class OnCollision {
        public UnityEvent enter;
        public UnityEvent exit;
        public UnityEvent stay;
    }
    public class OnTrigger {
        public UnityEvent enter;
        public UnityEvent exit;
        public UnityEvent stay;
    }
}