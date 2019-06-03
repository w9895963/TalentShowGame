using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static FlowEvent;


public class FlowManager : MonoBehaviour {
    public GameObject obj;
    public GameObject currentFlow;
    public GameObject previousFlow;

    [ReadOnly]
    public GameObject[] allFlow;


    void Start () {

        allFlow =
            GetComponentsInChildren<FlowEvent> ()
            .Select (x =>
                x.gameObject).ToArray ();


        UpdateCurrentFlow ();
        UpdatePreviousFlow ();

        UpdateObjectsActive ();


    }


    void Update () {
        UpdateObjectsActive ();

        if (currentFlow == default (GameObject)) {
            Debug.LogError ("流程系统中的名字无法与当前流程形成对应，可能是没有正确取名", gameObject);
            Debug.Break ();
        }
    }

    private void OnValidate () {

    }


    public void UpdateCurrentFlow () {
        currentFlow = Array.Find (allFlow, x => GetComponent<Animator> ()
            .GetCurrentAnimatorStateInfo (0)
            .IsName (x.name));

    }
    public void UpdateCurrentFlow (AnimatorStateInfo stateInfo) {
        currentFlow = Array.Find (allFlow, x =>
            stateInfo.IsName (x.name));

    }


    public void UpdatePreviousFlow () {
        previousFlow = currentFlow;
    }

    private void UpdateObjectsActive () {
        if (EditorApplication.isPlaying) {

            allFlow.ToList ()
                .ForEach (x => {
                    x.SetActive (false);
                });

            currentFlow?.SetActive (true);
        }
    }


    public void CallEvent (GameObject obj, FlowEventType et) {


        var getAllActiveEvents =
            obj.GetComponents<FlowEvent> ().ToList ()
            .FindAll (e =>
                e.enabled);


        getAllActiveEvents.ForEach (e => {

            bool testResult = true;

            if (e.enableEnterTest &
                !e.allowEnterFlow.ToList ()
                .Exists (x =>
                    x == previousFlow
                )
            ) {

                testResult = false;
            }

            if (testResult) {

                if (et == FlowEventType.OnEnter)
                    e.onEnter.Invoke ();
                else if (et == FlowEventType.OnExit)
                    e.onExit.Invoke ();

            };
        });


    }

}