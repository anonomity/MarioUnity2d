using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelTrigger : MonoBehaviour
{
    public int timeLeft = 0;
    public static bool doneCount = false;
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
        SoundManager.PlaySound("couting");
        Player_Move.moveAlone = false;
        // Before it does this mario disappears, converts time into points, flag goes up
        trig.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        trig.gameObject.GetComponent<Renderer>().enabled = false;
        Player_Score.normalSub = false;

    }
}
