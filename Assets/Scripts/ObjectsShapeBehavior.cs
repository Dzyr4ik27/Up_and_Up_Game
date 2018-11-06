using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsShapeBehavior : MonoBehaviour
{
    private Transform objectTransform;

    public bool needToGrowUp;
    public float growUpSpeed;

    public float maxValue;
    public float minValue;

    private void Awake() {
        objectTransform = transform;
    }

    private void FixedUpdate() {
        if (needToGrowUp) GrowUp();
    }

    public void GrowUp() {
        if (objectTransform.localScale.x >= minValue && objectTransform.localScale.x <= maxValue) {
            objectTransform.localScale += Vector3.one * growUpSpeed * Time.deltaTime;
        }
        
    }
}
