using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using static InputManager;

public class FS_Manager : MonoBehaviour {


    public static GameObject currentFocus;
    public GameObject _currentFocus;

    public static List<GameObject> focusList = new List<GameObject> ();

    public GameObject[] _focusList = new GameObject[0];
    public InputType[] sendInput;

    public Test test;


    void Start () {


    }
    void Update () {
        _focusList = focusList.ToArray ();
        _currentFocus = currentFocus;

        if (focusList.Count > 0) {
            InputSender.SendInput (new GameObject[] { focusList.Last () }, sendInput);
        }
    }
    private void OnValidate () {


        if (test.addFocus) {
            _AddFocus (test.gameObject);
            test.addFocus = false;
        }
        if (test.removeFocus) {
            _RemoveFocus (test.gameObject);
            test.removeFocus = false;
        }
        if (test.clear) {
            _Clear ();
            test.clear = false;
        }
    }


    public void _AddFocus (GameObject obj) {
        AddFocus (obj);
    }
    public static void AddFocus (GameObject obj) {


        if (obj != null) {
            if (!focusList.Exists (x => x == obj)) {
                focusList.Add (obj);;
            }
        }


        if (currentFocus != focusList.Last ()) {

            CallEvent ();

        }
    }


    public void _RemoveFocus (GameObject obj) {

        RemoveFocus (obj);
    }
    public static void RemoveFocus (GameObject obj) {

        if (focusList.Count () > 0) {
            focusList.Remove (obj);


            if (IsChange ()) {

                CallEvent ();
            }
        }
    }


    public void _Clear () {
        Clear ();
    }
    public static void Clear () {
        focusList = new List<GameObject> ();

        if (IsChange ()) {
            CallEvent ();
        }
    }

    [Serializable]
    public class Test {
        public bool addFocus;
        public bool removeFocus;
        public bool clear;
        public GameObject gameObject;
    }


    private static bool IsChange () {
        return currentFocus != (focusList.Count () > 0 ? focusList.Last() : null);
    }
    private static void CallEvent () {
        if (currentFocus != null) {
            foreach (FSFocusEvent ev in currentFocus.GetComponents<FSFocusEvent> ()) {
                if (ev.enabled & ev.gameObject.activeSelf) ev.deFocus.Invoke ();
            }
        }
        if (focusList.Count > 0) {

            currentFocus = focusList.Last ();

            foreach (FSFocusEvent ev in currentFocus.GetComponents<FSFocusEvent> ()) {
                if (ev.enabled & ev.gameObject.activeSelf) ev.onFocus.Invoke ();
            }

        } else { currentFocus = null; }

    }
}