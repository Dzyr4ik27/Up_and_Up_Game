﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private RaycastHit hit;

    public bool sidewayMovement;
    public float sidewaySpeed;
    public float leftEndPoint;
    public float rightEndPoint;
 
    public bool rotation;
    public float rotationSpeed;

    public bool upDownMovement;

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
    }

    public void SidewayMove() {
        //if (transform.position.x >= rightEndPoint || transform.position.x <= leftEndPoint) {
        //    sidewaySpeed *= -1f;
        //}
        objTransform.Translate(Vector3.right * sidewaySpeed * Time.fixedDeltaTime);
    }

    public void Rotate() {
        objTransform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
    }

    public void UpDownMove() {

    }

    

}
