using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoxCollider : MonoBehaviour
{
    public float rayDistance = 1f;
    // Start is called before the first frame update


    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (trigger.tag == "Player")
        {
            Debug.Log("Hit the coin");
            // Destroy(rayUp.collider.gameObject);
            SoundManager.PlaySound("coin");
            Player_Score.playerScore += 200;
            Player_Score.coinCount += 1;
            GetComponent<Animator>().SetBool("isHit", true);


        }
    }





}
