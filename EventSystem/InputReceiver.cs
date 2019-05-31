using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static InputManager;

public class InputReceiver : MonoBehaviour {
    public Event[] eventSetup = new Event[1];
    void Start () {

    }


    void Update () {
       
    }




    [Serializable]
    public class Event {
        public InputType inputType;
        public UnityEvent keyDown;
        public UnityEvent keyUp;
    }
}