using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFunction : MonoBehaviour {


    public void _Log (string st) {
        Debug.Log (st);
    }
    public void _Log (GameObject st) {
        Debug.Log (st);
    }
    public void _Break () {
        Debug.Break ();
    }
}