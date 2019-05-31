using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float speed = 1f;

    private Vector2 axis;

    [SerializeField]
    private Debug debug = new Debug();

    void Start () {

    }

    void Update () {
        axis.y = 0 + (Input.GetKey (InputManager.up) ? 1 : 0) + (Input.GetKey (InputManager.down) ? -1 : 0);
        axis.x = 0 + (Input.GetKey (InputManager.right) ? 1 : 0) + (Input.GetKey (InputManager.left) ? -1 : 0);

        if (axis != Vector2.zero) {
            GetComponent<Rigidbody2D> ().velocity = axis.normalized * speed;
        }

        debug.axis = axis;

    }

    [Serializable]
    private class Debug {
        public Vector2 axis;
    }
}