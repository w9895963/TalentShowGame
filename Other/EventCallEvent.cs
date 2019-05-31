using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCallEvent : MonoBehaviour {
    // Start is called before the first frame update
    public UnityEvent[] call;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }


    public void CallEvent (int i) {
        call[i].Invoke();
    }
}