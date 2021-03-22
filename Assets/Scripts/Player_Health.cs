using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{
    public bool hasDied;
    public int health;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -6)
        {
            Die();
        }

    }

    void Die()
    {
        SoundManager.PlaySound("die");
        SceneManager.LoadScene("Prototype_1");
    }
}
