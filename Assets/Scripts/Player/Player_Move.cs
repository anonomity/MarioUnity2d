using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{

    public int playerSpeed = 10;
    public int playerJumpPower = 1750;

    private float moveX;
    private float moveY;
    public bool isGrounded = true;
    public bool isBoxHit = false;

    public bool isBig = false;

    Rigidbody2D rb2d;
    string buttonPressed;

    public static float distanceToBottomOfPlayer = 1f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerRaycast();


        AnimationChecks();

    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }



    void Jump()
    {
        // SoundManager.PlaySound("jump");
        float jumpVelocity = 30f;
        rb2d.velocity = Vector2.up * jumpVelocity;
        isGrounded = false;

    }
    void AnimationChecks()
    {
        if (gameObject.transform.position.y > -2 && isGrounded == false)
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }

        if (moveX != 0 && gameObject.transform.position.y < -1.01)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, distanceToBottomOfPlayer);


        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy")
        {

            isGrounded = true;

        }

    }
}















/// Interesting Jump Mechanics
//   if (Input.GetButtonDown("Jump") && isGrounded)
//         {
//             Jump();
//         }
//         if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             if (isGrounded)
//             {
//                 rb2d.velocity = new Vector2(-playerSpeed, rb2d.velocity.y);
//             }
//             else
//             {
//                 float midAirControl = 1f;
//                 rb2d.velocity += new Vector2(-playerSpeed * midAirControl * Time.deltaTime, 0);
//                 rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -playerSpeed, +playerSpeed), rb2d.velocity.y);
//             }
//         }
//         else if (Input.GetKey(KeyCode.RightArrow))
//         {
//             rb2d.velocity = new Vector2(playerSpeed, rb2d.velocity.y);
//         }
//         else
//         {
//             if (isGrounded)
//             {
//                 rb2d.velocity = new Vector2(0, rb2d.velocity.y);
//             }
//         }