using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    
    private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb { get { return playerRb; } set { playerRb = value; } }
    public float tapForce;

    private void Awake() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) {
            Jump();
        }
    }

    public void Jump() {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * tapForce, ForceMode2D.Impulse);
    }
}
