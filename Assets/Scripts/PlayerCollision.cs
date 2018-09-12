using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    private float yDiePosition = -5.5f;

    private void Update() {
        DeleteObject();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.collider.tag) {
            case "Obstacle" : {
                    OnPlayerDied();
                    break;
                }
        }
    }

    public void DeleteObject() {
        if (transform.position.y <= yDiePosition + FindObjectOfType<CameraBehavior>().transform.position.y) {
            OnPlayerDied();
        }
    }
}
