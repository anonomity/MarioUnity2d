﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;
    public bool isGrounded = true;

    public bool isBoxHit = false;

    public float distanceToBottomOfPlayer = 1.2f;
    void Update()
    {
        PlayerRaycast();
        PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (gameObject.transform.position.y > -2 && isGrounded == false)
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if (moveX != 0 && gameObject.transform.position.y < -2.01)
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }


    void Jump()
    {
        SoundManager.PlaySound("jump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }


    void PlayerRaycast()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);


        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy")
        {

            isGrounded = true;
        }
    }
}
