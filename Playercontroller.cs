using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{ 
    Transform trans;
    Rigidbody2D body;

    [SerializeField] float speed; //we want to add thi in the spector in the unity
    [SerializeField] float jumpForce;
    [SerializeField] float dashForce;
    [SerializeField] float walljumpForce;

    bool jumpInput;
    bool isGrounded;
    bool canDash;
    bool rollInput;

    //wall sliding
    private bool IsWallSliding;
    private float wallSlidingSpeed = 1.5f;

    //wall jumping (courtesy of bendux on yt)
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float WallJumpingCounter;
    private float WallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>(); // takes the game object , get specific component and applies it to variable; 
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jumpInput = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumpInput = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rollInput = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rollInput = false;
        }

        WallSlide();
        WallJump();




    }
    void FixedUpdate() // it's meant for any physics updates
    {
        if(jumpInput && isGrounded)
        {
            jump();
        }
       // jump();
       if(rollInput && canDash)
        {
            roll();
        }
    }
    void walk()
    {
       if(Input.GetKey(KeyCode.RightArrow)) // detect while walking is the player input
       {
            trans.position += transform.right * Time.deltaTime * speed; // Time.deltaTime, it does not depend on the performance of your computer
            trans.rotation = Quaternion.Euler(0, 0, 0); // set the rotation of game object
       }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0); //change y rotation to 180
        }

    }
    void jump()
    {
        /* if (Input.GetKey(KeyCode.W))
         {
             body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
         }
         it's always jumped
        */
        
        body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        
    }

    void roll()
    {
        body.AddForce(transform.right * dashForce, ForceMode2D.Impulse);
        canDash = false;
    }

    void walljumpforce()
    {
        if (Physics2D.Raycast(transform.position, Vector2.left, 0.55f))
        {
            body.AddForce(-transform.right * dashForce, ForceMode2D.Impulse);
            body.AddForce(transform.up * walljumpForce, ForceMode2D.Impulse);
            trans.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Physics2D.Raycast(transform.position, Vector2.right, 0.55f))
        {
 
            body.AddForce(transform.right * 9, ForceMode2D.Impulse);
            body.AddForce(transform.up * walljumpForce, ForceMode2D.Impulse);
            trans.rotation = Quaternion.Euler(0, 180, 0);

        }
        // ctrl k u this tre


    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !isGrounded)
        {
            IsWallSliding = true;
            body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
        else
        {
            IsWallSliding = false;
        }
    }

    //wall jumping

    private void WallJump()
    {
        if(IsWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -trans.localScale.x;
            WallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            WallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z) && WallJumpingCounter > 0f)
        {
            isWallJumping = true;
            WallJumpingCounter = 0f;
            walljumpforce();
        }

        if (transform.localScale.x != wallJumpingDirection)
        {

        }

        Invoke(nameof(StopWallJumping), WallJumpingDuration);
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) // detects when the object collides with another object
    {
        if(collision.collider.tag == "Ground") // saying if the thing you're colliding with has the ground tag on it
        {
            for(int i=0; i < collision.contacts.Length; i++) // if any one of the collisions is on the ground
            {
                if (collision.contacts[i].normal.y > 0.5) 
                {
                    isGrounded = true;
                    canDash = true;
                }
            }
        }
    }
}
