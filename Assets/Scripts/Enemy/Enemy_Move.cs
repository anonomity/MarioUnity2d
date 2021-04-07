using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    public float hitDistance = 0.8f;
    public float distanceToBottomOfPlayer = 1f;
    public bool playerHit = false;

    void Update()
    {
        FlipRayCast();
        if (playerHit)
        {

        }
    }
    private void FixedUpdate()
    {
        DeathRayCast();

    }

    void DeathRayCast()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), distanceToBottomOfPlayer);
        RaycastHit2D rayRight = Physics2D.Raycast(transform.position, Vector2.right, 0.8f);
        RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        // if (hit)
        // {
        //     if (hit.collider.tag == "Player")
        //     {
        //         hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5f;
        //         GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        //         GetComponent<Rigidbody2D>().gravityScale = 8;
        //         GetComponent<Rigidbody2D>().freezeRotation = false;
        //         GetComponent<CapsuleCollider2D>().enabled = false;
        //         GetComponent<Enemy_Move>().enabled = false;
        //     }
        // }
        if (rayRight)
        {
            if (rayRight.collider.tag == "Player")
            {

                Player_Health.Die();
            }
        }

        if (rayLeft)
        {
            if (rayLeft.collider.tag == "Player")
            {
                Player_Health.Die();
            }
        }
    }

    void FlipRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;


        if (hit.distance < 1f)
        {

            if (hit.collider != null)
            {




                Flip();

            }
        }

    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
