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

    public static bool endGame = false;

    Rigidbody2D rb2d;
    string buttonPressed;

    public static float distanceToBottomOfPlayer = 1f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {



        AnimationChecks();

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (endGame)
        {

            EndGame();
        }
    }

    private void EndGame()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;

        endGame = false;
        // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0) * 2.5f;
    }
    private void FixedUpdate()
    {


        PlayerRaycast();

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

        if (moveX != 0)
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



        if (rayDown.collider != null && rayDown.collider.tag == "ground")
        {
            isGrounded = true;
        }


        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer)
        {
            isGrounded = true;
        }
        if (rb2d.velocity.y > 0)
        {
            isGrounded = false;
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