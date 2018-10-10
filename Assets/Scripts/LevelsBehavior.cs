using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsBehavior : MonoBehaviour {

    private Transform levelTransform;
    public float levelSpeed;

    public float zeroYPosition;

    private float levelLength;

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
        DeleteLevel();
    }

    private void FixedUpdate() {
        MoveLevel();
    }

    public void MoveLevel() {
        levelTransform.Translate(Vector2.down * levelSpeed * Time.deltaTime);
    }


    public void DeleteLevel() {
        if (playerTransform.position.y >= levelTransform.position.y + levelLength - zeroYPosition) {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }




}
