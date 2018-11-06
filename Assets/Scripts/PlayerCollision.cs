using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    private float yDiePosition = -5.5f;
    private Transform playerTransform;
    public Transform PlayerTransform { get { return playerTransform; } set { playerTransform = value; } }


    #region Other References

    private SpawnLevels spawnLevels;
    private SidewayWalls sidewayWalls;

    #endregion

    private void Awake() {
        playerTransform = transform;
    }

    private void Start() {
        spawnLevels = FindObjectOfType<SpawnLevels>();
    }

    private void Update() {
        CheckForDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.collider.tag) {
            case "Obstacle" : {
                    OnPlayerDied();
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.tag) {
            case "BeginLevel": {
                    collision.enabled = false;
                    spawnLevels.SpawnLevel();
                    break;
                }
            case "Darkness": {
                    collision.enabled = false;
                    OnPlayerDied();
                    break;
                }
            case "Attracted": {
                    collision.enabled = false;
                    collision.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                    break;
                }
            case "SpawnWalls": {
                    sidewayWalls = collision.transform.parent.GetComponent<SidewayWalls>();
                    collision.enabled = false;
                    sidewayWalls.StartCoroutine("WallSpawner");
                    break;
                }
            case "MoveTrig": {
                    collision.enabled = false;
                    collision.transform.parent.GetComponent<MovementBehavior>().StartCoroutine("SetMovement");
                    break;
                }
            case "SpawnObstacles": {
                    collision.enabled = false;
                    collision.transform.parent.GetComponent<SpawnObstacles>().StartCoroutine("Spawn");
                    break;
                }
        }
    }

    public void CheckForDeath() {
        if (playerTransform.position.y <= yDiePosition + FindObjectOfType<CameraBehavior>().cameraTransform.position.y) {
            OnPlayerDied();
        }
    }
}
