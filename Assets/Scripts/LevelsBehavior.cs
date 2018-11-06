using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsBehavior : MonoBehaviour {

    private Transform levelTransform;
    private float levelLength;

    public float zeroYPosition;

    private SpawnLevels spawnLevels;

    private Transform playerTransform;
    
    private void Awake() {
        levelTransform = transform;
    }

    private void Start() {
        spawnLevels = FindObjectOfType<SpawnLevels>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        levelLength = spawnLevels.CurrentLevelLength;
    }

    private void Update() {
        if (playerTransform.position.y >= levelTransform.position.y + levelLength - zeroYPosition) {
            Destroy(gameObject);
        }
    }






}
