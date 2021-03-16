using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Score : MonoBehaviour

{
    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score : " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
    }
}
