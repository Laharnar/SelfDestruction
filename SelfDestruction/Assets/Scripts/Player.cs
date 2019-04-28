using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] Vector2 moveDone;
    [SerializeField] float jump;
    bool jumped = false;
    public float jumpSpeed = 1f;
    //public float jumpHeight = 1f;
    public float moveSpeed = 1f;
    public float fallSpeed = 1f;

    public bool touchGroundToAllowJump = false;
    public bool touchedGround = true;

    public float facingDirection = 1;
    public ArmController arm;

    public float fireRate = 0.1f;
    float fireTime;
    public int sPCount=0;
    [SerializeField] private Text sPCounter;

    public Animator playerAnimation;

    public Sprite powerupBody;
    public Sprite powerupArm;
    public Sprite normalBody;
    public Sprite normalArm;
    public SpriteRenderer bodySprite;
    public SpriteRenderer hand1;
    public SpriteRenderer hand2;

    
    // Start is called before the first frame update
    void Start()
    {
        if(arm == null)
            arm = GetComponent<ArmController>();
        StartCoroutine(JumpHandler());
    }

    // Update is called once per frame
    void Update()
    {
        // left, right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && touchedGround) {
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumped = true;
            touchedGround = false;
            playerAnimation.SetTrigger("Jump");
        }
        rigidbody.AddForce(Vector2.right * horizontalInput * moveSpeed, ForceMode2D.Force);

        /*if (touchGroundToAllowJump && touchedGround || !touchGroundToAllowJump){
            
        }*/
        //moveDone.x = horizontalInput*moveSpeed*Time.deltaTime;
        if (horizontalInput != 0) {
            facingDirection = horizontalInput;
        }
        // left/right scaling
        transform.localScale = new Vector3(facingDirection, 1, 1);


        Vector3 aimPt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arm.UpdateArmDirection(aimPt, facingDirection < 0); // for negative, turn the aiming
        if (Input.GetKey(KeyCode.Mouse0) && fireTime < Time.time) {
            if (sPCount > 0)
            {
                arm.SpecialAttack();
                sPCount--;
                sPCounter.text = "" + sPCount;
                ChangeSprite();
            }
            fireTime = Time.time + fireRate;
            arm.Fire();

        }


    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            jump = 0;
            touchedGround = true;
        }
    }

    IEnumerator JumpHandler() {
        yield break;
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
       // rigidbody.MovePosition((Vector2)transform.position + moveDone);
        /*if (jumped == false) {
            jump -= 0.1f;
            if (jump < 0) {
                jump = 0;
            }
            moveDone.y = jump;
        }*/
    }

    public void ChangeSprite()
    {
        if (sPCount > 0)
        {
            bodySprite.sprite = powerupBody;
            hand1.sprite = powerupArm;
            hand2.sprite = powerupArm;
        }
        else
        {
            bodySprite.sprite = normalBody;
            hand1.sprite = normalArm;
            hand2.sprite = normalArm;
        }
            
    }
}
