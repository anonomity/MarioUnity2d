using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    public float hitDistance = 0.8f;
    public float distanceToBottomOfPlayer = 1f;

    void Update()
    {
        FlipRayCast();
        DeathRayCast();
    }


    void DeathRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), distanceToBottomOfPlayer);
        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5f;
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
                GetComponent<Rigidbody2D>().gravityScale = 8;
                GetComponent<Rigidbody2D>().freezeRotation = false;
                GetComponent<CapsuleCollider2D>().enabled = false;
                GetComponent<Enemy_Move>().enabled = false;
            }
        }
    }

    void FlipRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;


        if (hit.distance < 0.8f)
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
