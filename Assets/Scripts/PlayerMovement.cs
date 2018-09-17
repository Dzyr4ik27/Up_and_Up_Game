using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    
    private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb { get { return playerRb; } set { playerRb = value; } }
    public float tapForce;
    private Vector2 jumpVector;
    private float xJumpPos;
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
        MouseInput();
    }

    public void SidewayJump() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            xJumpPos = -0.45f;
            UpJump();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            playerRb.velocity = Vector2.zero;
            xJumpPos = 0.45f;
            UpJump();
        }
    }

    public void UpJump() {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(new Vector2(xJumpPos, yJumpPos) * tapForce, ForceMode2D.Impulse);
        audioManager.Play("Jump");
    }

    public void MouseInput() {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2f) {
            xJumpPos = -0.45f;
            UpJump();
        } else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2f) {
                xJumpPos = 0.45f;
                UpJump();
            }
    }
}
