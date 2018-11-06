using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This object contains:
 * points array
 * spawnObject
 * trigger
 */
 
public class SpawnObstacles : MonoBehaviour {

    public GameObject objectToSpawn;
    public Transform[] spawnPointsArray;
    public int objectsCount;
    public float spawnTime;

    private int pointsCount;

    public bool randomSpawn;
    public bool spawnAtStart;

    private Vector2 spawnPoint;

    private void Awake() {
        pointsCount = spawnPointsArray.Length;
    }

    IEnumerator Spawn() {
        for (int i = 0; i < objectsCount; ++i) {
            yield return new WaitForSeconds(spawnTime);

            if (randomSpawn) {
                spawnPoint = spawnPointsArray[Random.Range(0, pointsCount)].transform.position;
            } else {
                spawnPoint = spawnPointsArray[i].transform.position;
            }
            
            
            GameObject instance = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
            instance.SetActive(true);
        }
    }

    private void Start() {
        if (spawnAtStart) StartCoroutine("Spawn");
    }
}
