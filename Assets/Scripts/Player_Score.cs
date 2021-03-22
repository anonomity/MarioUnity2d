using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Score : MonoBehaviour

{
    private float timeLeft = 120;
    public static int playerScore = 0;
    public static int coinCount = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    public GameObject playerCoinUI;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("" + playerScore);
        playerCoinUI.gameObject.GetComponent<Text>().text = ("" + coinCount);

        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {

            CountScore();

        }
        if (trig.gameObject.name == "Coin")
        {
            playerScore += 10;
            coinCount += 1;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        DataManagement.datamanagement.highScore = playerScore + (int)(timeLeft * 10);
        DataManagement.datamanagement.SaveData();
        Debug.Log("High Score" + DataManagement.datamanagement.highScore);
    }
}
