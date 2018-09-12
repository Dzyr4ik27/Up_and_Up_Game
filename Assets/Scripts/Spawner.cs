using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject obstacle;
    private float spawnTime = .1f;
    private Vector3 spawnPosition;
    private float yOffset = 5f;
    private float tempYOffset;
    private float minXPos = -2f;
    private float maxXPos = 2f;
    private GameObject cube;

    private void Awake() {
        tempYOffset = yOffset;
    }

    private void Start() {
        StartCoroutine("SpawnObjects");
    }

    IEnumerator SpawnObjects() {
        for (int i = 0; i < 5; ++i) {
            yield return new WaitForSeconds(spawnTime);
            SpawnOneObject();
            yOffset += tempYOffset;
        }  
    }

    public void SpawnOneObject() {
        spawnPosition = new Vector3(Random.Range(minXPos, maxXPos), yOffset, 0f);
        cube = (GameObject)Instantiate(obstacle, spawnPosition, Quaternion.identity);
        cube.transform.parent = transform;
    }
}
