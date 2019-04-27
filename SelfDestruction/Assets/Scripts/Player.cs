using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] Vector2 moveDone;
    [SerializeField] float jump;
    bool jumped = false;
    public float jumpSpeed = 1f;
    public float moveSpeed = 1f;
    public float fallSpeed = 1f;

    public bool touchGroundToAllowJump = false;
    public bool touchedGround = true;

    public float facingDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JumpHandler());
    }

    // Update is called once per frame
    void Update()
    {
        // left, right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (touchGroundToAllowJump && touchedGround || !touchGroundToAllowJump){
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumped = true;
                touchedGround = false;
            }
        }
        moveDone.x = horizontalInput*moveSpeed*Time.deltaTime;
        if (horizontalInput != 0) {
            facingDirection = horizontalInput;
        }
        // left/right scaling
        transform.localScale = new Vector3(facingDirection, 1, 1);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            jump = 0;
                touchedGround = true;
        }
    }

    IEnumerator JumpHandler() {
        while (true) {
            if (jumped) {
                jump = jumpSpeed;
                moveDone.y = jump;
                yield return null;
                while (jump > 0) {
                    yield return null;
                    jump -= fallSpeed;
                    moveDone.y = jump*Time.deltaTime;
                }
                jump = 0;
                jumped = false;
            }
            yield return null;
        }
    }

    private void FixedUpdate() {
        rigidbody.MovePosition((Vector2)transform.position + moveDone);
        /*if (jumped == false) {
            jump -= 0.1f;
            if (jump < 0) {
                jump = 0;
            }
            moveDone.y = jump;
        }*/
    }
}
