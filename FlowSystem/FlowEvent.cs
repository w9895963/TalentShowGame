using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlowEvent : MonoBehaviour {
    public GameObject[] flowTest;
    public UnityEvent onEnter;
    public UnityEvent onExit;


    void Start () {

    }

    void Update () {

    }


    public  enum FlowEventType {
        OnExit,
        OnEnter
    }
}