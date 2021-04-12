using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool downPole = false;
    private bool sound = true;

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
        yield return new WaitForSeconds(time);

        if (sound)
        {
            SoundManager.PlaySound("downFlag");
            sound = false;
        }
        GetComponent<Animator>().SetBool("win", false);
        yield return new WaitForSeconds(time * 2);
        mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        mario.transform.Translate(0.5f, 0, 0);
        mario.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(time);
        Debug.Log("Flipping");

        mario.GetComponent<SpriteRenderer>().flipX = false;


        Player_Move.endGame = true;
        downPole = false;



    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            SoundManager.mute();
            mario = trig;
            //Freeze Mario
            trig.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;


            ///turn off animations
            trig.GetComponent<Animator>().enabled = false;
            downPole = true;


            StartCoroutine(ExecuteAfterTime(1));
            GetComponent<Animator>().SetBool("win", true);

            //Animate

            // GetComponent<Animator>().SetBool("win", false);
        }

    }


    //Push Mario down until he gets to y = -1.1
    void downThePole()
    {

        if (mario.transform.position.y > -0.9)
        {

            mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f) * 1.5f;

        }

    }
}
