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
    public int objectsCount;

    public Transform[] spawnPointsArray;
    private int pointsCount;

    private Vector2 spawnPoint;
    public float spawnTime;


    IEnumerator Spawn() {
        for (int i = 0; i < objectsCount; ++i) {
            yield return new WaitForSeconds(spawnTime);

            spawnPoint = spawnPointsArray[Random.Range(0, pointsCount)].transform.position;
            GameObject instance = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
            instance.SetActive(true);
        }
    }

    private void Awake() {
        pointsCount = spawnPointsArray.Length;
    }
}
