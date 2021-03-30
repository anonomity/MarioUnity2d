using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
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


            // Do the scene of Mario walking into the castle

            //go to the next level
            // LoadNextLevel(1);

        }

    }
    //Push Mario down until he gets to y = -1.1
    void downThePole()
    {
        mario.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.5f) * 1.5f;

        if (mario.transform.position.y < -1.6f)
        {
            downPole = false;
        }
    }
}
