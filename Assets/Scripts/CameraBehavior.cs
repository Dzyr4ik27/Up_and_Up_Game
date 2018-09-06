using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public Transform target;
    private Vector3 newPosition;
    public float smoothSpeed;
    public float yOffset;

    private float cameraSize;
    private float defaultScreenWidth = 320f;

    // uncomment only on mobile
    private void Awake() {
        //cameraSize = Screen.width / (defaultScreenWidth / Camera.main.orthographicSize);
        //Camera.main.orthographicSize = cameraSize;
    }

    private void FixedUpdate() {
        SmoothFollow();
    }

    public void SmoothFollow() {
        if (target.position.y > transform.position.y - yOffset) {
            newPosition = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.fixedDeltaTime);
        }
        
    }
}
