using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Score : MonoBehaviour

{
    public static float timeLeft = 120;
    public static float playerScore = 0;
    public static int coinCount = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    public GameObject playerCoinUI;
    public static bool normalSub = true;
    // Update is called once per frame
    void Update()
    {

        timeLeftUI.gameObject.GetComponent<Text>().text = ("" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("" + (int)playerScore);
        playerCoinUI.gameObject.GetComponent<Text>().text = ("" + coinCount);

        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Level_1");
        }
    }
    private void FixedUpdate()
    {
        if (normalSub)
        {

            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft -= Time.deltaTime * 30;
            playerScore += Time.deltaTime * 30;
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.name == "Coin")
        {
            playerScore += 10;
            coinCount += 1;
            Destroy(trig.gameObject);
        }
    }


}
