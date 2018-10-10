using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private RaycastHit hit;

    public bool sidewayMovement;
    public bool moveToPoints;

    public float sidewaySpeed;
    public float rightEndPoint;
    public float leftEndPoint;
 
    public bool rotation;
    public float rotationSpeed;

    public bool upDownMovement;
    public float speed;
    public float upEndPoint;
    public float downEndPoint;

    public bool needToStop;

    private Transform objTransform;

    private void Awake() {
        objTransform = transform;
    }

    private void FixedUpdate() {
        if (rotation) Rotate();
        if (sidewayMovement) SidewayMove();
        if (upDownMovement) UpDownMove();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "wall") {
            sidewaySpeed *= -1;
        }
        if (needToStop) {
            sidewaySpeed = 0f;
        }
    }


    public void SidewayMove() {
        if (moveToPoints) {
            if (objTransform.localPosition.x >= rightEndPoint || objTransform.localPosition.x <= leftEndPoint) {
                sidewaySpeed = needToStop ? 0f : -sidewaySpeed;
            }
        }
        objTransform.Translate(Vector3.right * sidewaySpeed * Time.deltaTime);
    }

    public void Rotate() {
        objTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void UpDownMove() {
        if (objTransform.localPosition.y >= upEndPoint || objTransform.localPosition.y <= downEndPoint) {
            //upDownSpeed *= -1f;
            speed = needToStop ? 0f : -speed;
        }
        objTransform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    

}
