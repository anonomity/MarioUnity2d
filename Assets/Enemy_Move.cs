using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
        if(hit.distance < 1f) {
            Flip ();
        }
        
    }

    void Flip () {
        if(XMoveDirection > 0){
            XMoveDirection = -1;
        } else{
            XMoveDirection = 1;
        }
    }
}
