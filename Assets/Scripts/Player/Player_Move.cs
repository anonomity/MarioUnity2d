using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{

    public int playerSpeed = 10;
    public int playerJumpPower = 1750;

    private float moveX;
    private float moveY;

    public bool isBoxHit = false;

    public bool isBig = false;

    public static bool endGame = false;

    Rigidbody2D rb2d;
    string buttonPressed;

    public static float distanceToBottomOfPlayer = 1f;
    public static bool moveAlone = false;
    public float distanceToBottomOfPlayer2 = 1f;
    public LayerMask groundLayer;
    [Header("Collision")]
    public float linearDrag = 1f;

    public float gravity = 1f;
    public float fallMultiplier = 5f;
    public bool isGrounded = true;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        PlayerRaycast();

    }
    void Update()
    {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distanceToBottomOfPlayer2, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        AnimationChecks();

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (endGame)
        {

            EndGame();
        }
        if (moveAlone)
        {


            Debug.Log("moveAlone");

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0) * 1.5f;
            gameObject.GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
    }

    private void EndGame()
    {
        Debug.Log("EndGame");

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;

        endGame = false;
        moveAlone = true;
    }


    // void ModifyPhysics()
    // {
    //     if (isGrounded)
    //     {
    //         rb2d.gravityScale = 0f;
    //     }
    //     else
    //     {
    //         rb2d.gravityScale = gravity;
    //         linearDrag = linearDrag * 0.15f;
    //         if (rb2d.velocity.y < 0)
    //         {
    //             rb2d.gravityScale = gravity * fallMultiplier;
    //         }
    //         else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
    //         {
    //             rb2d.gravityScale = gravity * (fallMultiplier / 2);
    //         }
    //     }
    // }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);

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