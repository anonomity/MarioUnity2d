﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Coin_An : MonoBehaviour
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
            trigger.GetComponent<Animator>().SetBool("isHit", true);


        }
    }





}
