﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActveEvent : MonoBehaviour {
   
    public UnityEvent onActive;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnEnable () {
        if (this.isActiveAndEnabled) onActive.Invoke ();
    }
    
}