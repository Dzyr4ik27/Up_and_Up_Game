using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{

    public GameObject[] objectsArray;
    public float time;

    private int objectsCount;

    private void Awake() {
        objectsCount = objectsArray.Length;
    }

    public IEnumerator SetMovement() {
        for (int i = 0; i < objectsCount; ++i) {
            yield return new WaitForSeconds(time);

            objectsArray[i].GetComponent<Movement>().enabled = true;
        }
        


    }
}
