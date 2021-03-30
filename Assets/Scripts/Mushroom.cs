using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, 0) * 1.5f;
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            trig.transform.localScale = new Vector2(1f, 1f) * 1.1f;
            Player_Move.distanceToBottomOfPlayer = 1.2f;
            Destroy(this.gameObject);

        }

    }
}
