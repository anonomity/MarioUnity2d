using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Coin_An : MonoBehaviour
{
    public bool isHit = false;
    public float rayDistance = 0.001f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            BoxRaycast();
        }
    }

    void BoxRaycast()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), rayDistance);
        if (rayDown)
        {
            if (rayDown.collider.tag == "Player")
            {
                Debug.Log("hit");
                // Destroy(rayUp.collider.gameObject);
                SoundManager.PlaySound("coin");
                Player_Score.playerScore += 200;
                Player_Score.coinCount += 1;
                GetComponent<Animator>().SetBool("isHit", true);
                isHit = true;


            }
        }


    }


}
