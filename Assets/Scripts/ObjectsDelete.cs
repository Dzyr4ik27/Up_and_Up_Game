using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDelete : MonoBehaviour {

    public  float yDiePosition = -5.5f;
    private Transform objTransform;

    private void Awake() {
        objTransform = transform;
    }

    private void Update() {
        if (objTransform.position.y < yDiePosition + FindObjectOfType<CameraBehavior>().transform.position.y) {
            Destroy(gameObject);
        }
    }
}
