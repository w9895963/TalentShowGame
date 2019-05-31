using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    [SerializeField]
    private KeyCode _up = KeyCode.W;
    public static KeyCode up = KeyCode.W;
    [SerializeField]
    private KeyCode _down = KeyCode.S;
    public static KeyCode down = KeyCode.S;
    [SerializeField]
    private KeyCode _left = KeyCode.A;
    public static KeyCode left = KeyCode.A;
    [SerializeField]
    private KeyCode _right = KeyCode.D;
    public static KeyCode right = KeyCode.D;
    [SerializeField]
    private KeyCode _interact = KeyCode.E;
    public static KeyCode interact = KeyCode.E;
    public static Dictionary<InputType, KeyCode> keyMap = new Dictionary<InputType, KeyCode> ();


    private void Start () {
        ApplyInspectorChange ();
        RenewKeyMap ();
    }


    private void OnValidate () {
        ApplyInspectorChange ();
        RenewKeyMap ();
    }
    private void Update () => UpdateInspectorDate ();


    private void ApplyInspectorChange () {
        up = _up;
        down = _down;
        left = _left;
        right = _right;
        interact = _interact;


    }
    private void UpdateInspectorDate () {
        _up = up;
        _down = down;
        _left = left;
        _right = right;
        _interact = interact;

    }
    private static void RenewKeyMap () {
        keyMap[InputType.Up] = up;
        keyMap[InputType.Down] = down;
        keyMap[InputType.Left] = left;
        keyMap[InputType.Right] = right;
        keyMap[InputType.Interact] = interact;
    }
    public enum InputType {
        Up,
        Down,
        Left,
        Right,
        Interact
    }
}