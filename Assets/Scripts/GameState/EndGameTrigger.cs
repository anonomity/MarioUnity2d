using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool downPole = false;
    private Collider2D mario = null;
    // Update is called once per frame
    void Update()
    {
        if (downPole)
        {
            downThePole();
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        mario.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Animator>().SetBool("win", true);
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().SetBool("win", false);
        downPole = false;
        mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        mario.transform.Translate(1f, 0, 0);
        StartCoroutine(ExecuteAfterTime(2));
        mario.GetComponent<SpriteRenderer>().flipX = true;
        Player_Move.endGame = true;

    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            mario = trig;
            //Freeze Mario
            trig.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;


            ///turn off animations
            trig.GetComponent<Animator>().enabled = false;
            downPole = true;

            //Animate

            // GetComponent<Animator>().SetBool("win", false);
        }

    }


    //Push Mario down until he gets to y = -1.1
    void downThePole()
    {

        if (mario.transform.position.y < -0.9)
        {
            GetComponent<Animator>().SetBool("win", true);


            StartCoroutine(ExecuteAfterTime(5));
        }
        else
        {

            mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f) * 1.5f;
        }
    }
}
