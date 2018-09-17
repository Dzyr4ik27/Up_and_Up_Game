using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public Transform target;
    private Vector3 newPosition;
    public float smoothSpeed;
    public float moveUpSpeed;
    public float yOffset;

    private float cameraSize;

    public int targetWidth = 640;
    public float pixelsToUnits = 100f;

    [HideInInspector]
    public Transform cameraTransform;

    private void Awake() {
        ScaleCamera();
        cameraTransform = transform;
    }

    private void FixedUpdate() {
        SmoothFollow();
        MoveUp();
    }

    public void SmoothFollow() {
        if (target.position.y > cameraTransform.position.y - yOffset) {
            newPosition = new Vector3(cameraTransform.position.x, target.position.y + yOffset, cameraTransform.position.z);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPosition, smoothSpeed * Time.fixedDeltaTime);
        }
    }

    public void ScaleCamera() {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);

        Camera.main.orthographicSize = height / pixelsToUnits / 2f;
    }

     public void MoveUp() {
        cameraTransform.Translate(Vector3.up * moveUpSpeed * Time.fixedDeltaTime);
    }
}
