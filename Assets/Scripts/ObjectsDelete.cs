using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDelete : MonoBehaviour {

    public  float yDiePosition = -5.5f;
    private Transform objectTransform;

    private void Awake() {
        objectTransform = transform;
    }

    private void Update() {
        if (objectTransform.position.y < yDiePosition + FindObjectOfType<CameraBehavior>().transform.position.y) {
            Destroy(gameObject);
        }
    }
}
