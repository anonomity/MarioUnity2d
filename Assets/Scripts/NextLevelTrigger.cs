using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelTrigger : MonoBehaviour
{
    public int timeLeft = 0;
    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    // Start is called before the first frame update
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        Player_Move.moveAlone = false;
        // Before it does this mario disappears, converts time into points, flag goes up
        trig.gameObject.GetComponent<Renderer>().enabled = false;
        Player_Score.normalSub = false;
        if (Player_Score.timeLeft < 0)
        {

            LoadNextLevel(1);
        }
    }
}
