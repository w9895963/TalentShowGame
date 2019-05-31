using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnimation : MonoBehaviour {
    public bool enable = true;
    public float timeLength = 0.05f;
    public float lessLength = 0.001f;
    [Header ("Read Only")]
    public bool walking;
    public Vector2 lastPosition;
    public float lastTime;
    public Vector2 velosity;
    public float walkAngle;
    public int walkAnimationDirection;

    // Start is called before the first frame update
    void Start () {
        lastPosition = GetComponent<Rigidbody2D> ().position;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (enable & Time.time - lastTime >= timeLength) {
            velosity = GetComponent<Rigidbody2D> ().position - lastPosition;
            walking = (velosity.x != 0 | velosity.y != 0) & velosity.magnitude > lessLength ? true : false;
            GetComponent<Animator> ().SetBool ("Walking", walking);

            if (walking) {
                walkAngle = Vector2.Angle (Vector2.right, velosity);
                walkAngle = velosity.y > 0 ? 360 - walkAngle : walkAngle;


                if (224 <= walkAngle & walkAngle < 316) {
                    walkAnimationDirection = 270;
                } else if (136 <= walkAngle & walkAngle < 224) {
                    walkAnimationDirection = 180;
                } else if (44 <= walkAngle & walkAngle < 136) {
                    walkAnimationDirection = 90;
                } else if (316 <= walkAngle | walkAngle < 44) {
                    walkAnimationDirection = 0;
                }

                GetComponent<Animator> ().SetInteger ("Walk Animation Direction", walkAnimationDirection);

                lastPosition = GetComponent<Rigidbody2D> ().position;
            }


            lastTime = Time.time;
        }


    }
}