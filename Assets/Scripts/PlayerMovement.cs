using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    
    private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb { get { return playerRb; } set { playerRb = value; } }
    public float tapForce;
    private Vector2 jumpVector;
    private float xJumpPos = 0.45f;
    private readonly float yJumpPos = 1f;

    private AudioManager audioManager;

    private void Awake() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update() {
        SidewayJump();
        //MouseInput();
    }

    public void SidewayJump() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            UpJump(new Vector2(-xJumpPos, yJumpPos));
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            UpJump(new Vector2(xJumpPos, yJumpPos));
        }
    }

    public void UpJump(Vector2 force_vector) {
        audioManager.Play("Jump");
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(force_vector * tapForce, ForceMode2D.Force);
    }

    //public void MouseInput() {
    //    if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2f) {
    //        xJumpPos = -0.45f;
    //        UpJump();
    //    } else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2f) {
    //            xJumpPos = 0.45f;
    //            UpJump();
    //        }
    //}
}
