using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("hit");

            trig.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            GetComponent<Rigidbody2D>().gravityScale = 8;
            GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Enemy_Move>().enabled = false;

        }

    }
}
