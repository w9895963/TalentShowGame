using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static InputManager;


public class InputSender : MonoBehaviour {


    public GameObject[] targets = new GameObject[1];

    public InputType[] inputTypes = new InputType[1];


    public DebugAndTest debug;


    void Start () {

    }
    void OnValidate () {
        if (debug.send) {
            debug.send = false;
            SendInput (targets, new InputType[] { debug.inputType }, ref debug.log, true);
        }
    }

    void Update () {
        if (debug.enableLog) {
            SendInput (targets, inputTypes, ref debug.log);
        } else {
            SendInput (targets, inputTypes);
            debug.log = "";
        }

    }


    public static void SendInput (GameObject[] targets, InputType[] inputTypes, ref string log, bool forceSend = false) {
        if (targets.Length > 0) {
            string logTemp = "";
            int count = 0;

            bool isInput = forceSend?true : false;
            foreach (InputType ty in inputTypes) {
                bool keydown = Input.GetKeyDown (keyMap[ty]);
                bool keyup = Input.GetKeyUp (keyMap[ty]);
                if (Input.GetKeyDown (keyMap[ty])) {
                    isInput = true;
                    break;
                }
                if (Input.GetKeyUp (keyMap[ty])) {
                    isInput = true;
                    break;
                }
            }

            if (isInput) {
                GameObject[] activeObjs = FilterActives (targets);

                logTemp += "active objects:" + activeObjs.Count () + "\n";

                List<InputReceiver> enableComs = getAllEnableReceivers (activeObjs);

                logTemp += "enable components:" + enableComs.Count () + "\n";


                foreach (InputType ty in inputTypes) {
                    int num = 0;
                    enableComs.ForEach (com => {
                        Array.ForEach (com.eventSetup, e => {
                            if (e.inputType == ty) {

                                if (!forceSend) {
                                    bool keydown = Input.GetKeyDown (keyMap[ty]);
                                    if (keydown) {
                                        e.keyDown.Invoke ();
                                        num += 1;
                                        count += 1;
                                    }
                                    bool keyup = Input.GetKeyUp (keyMap[ty]);
                                    if (keyup) e.keyUp.Invoke ();
                                } else {
                                    e.keyDown.Invoke ();
                                    num += 1;
                                    count += 1;
                                    e.keyUp.Invoke ();
                                }
                            }
                        });

                    });
                    if (num > 0) {
                        logTemp += ty + " success send:" + num + "\n";
                    }


                }
                log = count > 0 ? logTemp : log;
            }
        }
    }
    public static void SendInput (GameObject[] targets, InputType[] inputTypes) {
        string s = "";
        SendInput (targets, inputTypes, ref s);
    }


    public static GameObject[] FilterActives (GameObject[] objectArray) {
        return Array.FindAll (objectArray, ob => {
            if (ob != null) {
                if (ob.activeSelf) {
                    return true;
                } else return false;
            } else return false;

        });
    }
    public static List<InputReceiver> getAllEnableReceivers (GameObject[] enableObjs) {
        List<InputReceiver> enableComs = new List<InputReceiver> ();
        Array.ForEach (enableObjs, ob => {
            List<InputReceiver> results = ob.GetComponents<InputReceiver> ().ToList ().FindAll (x => x.enabled);
            enableComs.AddRange (results);
        });
        return enableComs;

    }

    [Serializable]
    public class DebugAndTest {
        public bool send;
        public bool enableLog;

        public InputType inputType;

        [Multiline (5)]
        public string log;


    }
}