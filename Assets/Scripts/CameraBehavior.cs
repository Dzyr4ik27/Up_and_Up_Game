using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public Transform target;
    private Vector3 newPosition;
    public float smoothTime;
    public float moveUpSpeed;
    public float moveUpTime;
    public float yOffset;

    private float cameraSize;

    public int targetWidth = 640;
    public float pixelsToUnits = 100f;

    [HideInInspector]
    public Transform cameraTransform;

    private Vector3 velocity = Vector3.zero;

    private void Awake() {
        ScaleCamera();
        cameraTransform = transform;
    }


    private void LateUpdate() {
        //SmoothFollow();
        //MoveUp();
        //EndlessSmoothFollow();
        //SmoothFollow();
    }   

    private void Update() {
        //MoveUp();
    }

    private void FixedUpdate() {
        //SmoothFollow();
    }

    public void SmoothFollow() {
        if (target.position.y >= cameraTransform.position.y - yOffset) {
            Vector3 pos = cameraTransform.position;
            pos.y = target.position.y + yOffset;
            newPosition = pos;
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, newPosition, ref velocity, smoothTime);
        } 

    }

    public void SmoothFollow2() {
        if (target.position.y >= cameraTransform.position.y - yOffset) {
            Vector3 pos = cameraTransform.position;
            pos.y = target.position.y + yOffset;
            newPosition = pos;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPosition, moveUpSpeed * Time.deltaTime);
        }
    }

    public void EndlessSmoothFollow() {
        Vector3 pos = cameraTransform.position;
        pos.y = target.position.y + yOffset;
        newPosition = pos;
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, newPosition, ref velocity, smoothTime);
    }

    public void ScaleCamera() {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);

        Camera.main.orthographicSize = height / pixelsToUnits / 2f;
    }

     public void MoveUp() {
        cameraTransform.Translate(Vector3.up * moveUpSpeed * Time.deltaTime);

        //cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, cameraTransform.position + Vector3.up * 1.5f,
        //    ref velocity, moveUpTime);
    }
}
