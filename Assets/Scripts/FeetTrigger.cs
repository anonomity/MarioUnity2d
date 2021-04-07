using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTrigger : MonoBehaviour
{
    // Start is called before the first  frame update


    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "enemy")
        {

            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 6f;
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
            enemy.GetComponent<Rigidbody2D>().gravityScale = 8;
            enemy.GetComponent<Rigidbody2D>().freezeRotation = false;
            enemy.GetComponent<CapsuleCollider2D>().enabled = false;
            enemy.GetComponent<Enemy_Move>().enabled = false;
        }

    }
}
