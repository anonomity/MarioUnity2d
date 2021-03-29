using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawn : MonoBehaviour
{
    public bool isHit = false;
    public float rayDistance = 1f;
    public GameObject mushroom;

    private void Update()
    {
        if (!isHit)
        {
            MushroomRaycast();
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }
    void MushroomRaycast()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), rayDistance);
        if (rayDown)
        {
            if (rayDown.collider.tag == "Player")
            {

                Player_Score.playerScore += 200;

                isHit = true;

                StartCoroutine(ExecuteAfterTime(5));

                Instantiate(mushroom, new Vector2(rayDown.transform.position.x, rayDown.transform.position.y + 2), Quaternion.identity);






            }
        }
    }
}
