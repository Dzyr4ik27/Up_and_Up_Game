using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewayWalls : MonoBehaviour {
    public GameObject obstacle;

    public float maxXPos = 1.3f;
    public float minXPos = -1.3f;
    public int wallCount;

    private float spawnXPoint;
    private float spawnYPoint;
    public float spawnTime;

    public float yOffset = 1f;

    private Transform playerTransform;

    public float wallSpeed = 2f;

    private void Start() {
        playerTransform = FindObjectOfType<PlayerCollision>().PlayerTransform;   
    }

    IEnumerator WallSpawner() {
        spawnYPoint = playerTransform.position.y + yOffset + 4f; // just offset

        for (int i = 0; i < wallCount; ++i) {
            yield return new WaitForSeconds(spawnTime);
            spawnXPoint = Random.Range(minXPos, maxXPos);
            
            GameObject wall =  (GameObject)Instantiate(obstacle, new Vector2(spawnXPoint, spawnYPoint), Quaternion.identity);
            wall.transform.parent = transform;
            wall.GetComponent<Movement>().sidewaySpeed = Random.Range(-wallSpeed, wallSpeed);
            spawnYPoint += yOffset;
        }
        
    }

}
