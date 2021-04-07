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


        }

    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }
    //Push Mario down until he gets to y = -1.1
    void downThePole()
    {

        if (mario.transform.position.y < -0.9)
        {

            downPole = false;
            mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            mario.transform.Translate(1f, 0, 0);
            StartCoroutine(ExecuteAfterTime(2));
            mario.GetComponent<SpriteRenderer>().flipX = true;
            Player_Move.endGame = true;
        }
        else
        {

            mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f) * 1.5f;
        }
    }
}
