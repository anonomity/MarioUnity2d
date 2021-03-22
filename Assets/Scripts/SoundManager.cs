using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, dieSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("coin");
        jumpSound = Resources.Load<AudioClip>("jump");
        dieSound = Resources.Load<AudioClip>("die");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSource.PlayOneShot(coinSound);
                break;
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "die":
                audioSource.PlayOneShot(dieSound);
                break;

        }
    }
}
