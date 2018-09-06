using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.collider.tag) {
            case "Obstacle" : {
                    OnPlayerDied();
                    break;
                }
        }
    }
}
