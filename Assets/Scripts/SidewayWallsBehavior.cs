using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewayWallsBehavior : MonoBehaviour {

    private Transform[] stripsArray;
    private int minRightPoint = -3;
    private int maxRightPoint = 44;
    private int stripsArrayLength;


    private void Awake() {
        stripsArrayLength = transform.childCount - 1;
        stripsArray = new Transform[stripsArrayLength];
        SetArrayElements();
    }

    private void Start() {
        SetEndPoints();
    }

    public void SetArrayElements() {
        for (int i = 0; i < stripsArrayLength; ++i) {
            stripsArray[i] = transform.GetChild(i);
        }
    }

    public void SetEndPoints() {
        
        foreach (Transform strip in stripsArray) {
            strip.GetComponent<Movement>().leftEndPoint = transform.position.x - 1f;
            strip.GetComponent<Movement>().rightEndPoint = Random.Range(transform.position.x - 1f, transform.position.x + 1f) ;
            strip.GetComponent<Movement>().sidewaySpeed =  Random.Range(2, 6) / 10f;
        }
    }
}
