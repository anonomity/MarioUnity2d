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
    private bool sound = true;
    private bool stop = false;
    public static bool normalSub = true;
    public bool Win = true;
    // Update is called once per frame
    IEnumerator ExecuteAfterTime(float time)
    {
        if (sound)
        {
            sound = false;
            SoundManager.PlaySound("winLevel");
        }
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level_2");
        // timeLeft = 200;


    }
    void Update()
    {

        timeLeftUI.gameObject.GetComponent<Text>().text = ("" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("" + (int)playerScore);
        playerCoinUI.gameObject.GetComponent<Text>().text = ("" + coinCount);

        if (timeLeft < 0.1f)
        {
            FlagUp.flagUp = true;
            stop = true;
            Player_Move.moveAlone = false;
            Player_Move.endGame = false;
            normalSub = true;

            StartCoroutine(ExecuteAfterTime(3));


        }
        // if (timeLeft < 0.1f)
        // {
        //     NextLevelTrigger.doneCount = true;
        // }
    }
    private void FixedUpdate()
    {
        if (normalSub && !stop)
        {

            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft > 0.01 && !stop)
        {

            timeLeft -= Time.deltaTime * 30;
            playerScore += Time.deltaTime * 60;
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
