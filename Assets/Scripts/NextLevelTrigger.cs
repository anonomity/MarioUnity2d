using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelTrigger : MonoBehaviour
{

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        LoadNextLevel(1);
    }
}
