using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, dieSound, downFlag, couting, winLevel;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("coin");
        jumpSound = Resources.Load<AudioClip>("jump");
        dieSound = Resources.Load<AudioClip>("die");
        downFlag = Resources.Load<AudioClip>("downFlag");
        couting = Resources.Load<AudioClip>("couting");
        winLevel = Resources.Load<AudioClip>("winLevel");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mute();
        }

    }

    public static void mute()
    {

        audioSource.mute = !audioSource.mute;
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
            case "downFlag":
                audioSource.PlayOneShot(downFlag);
                break;
            case "couting":
                audioSource.PlayOneShot(couting);
                break;
            case "winLevel":
                audioSource.PlayOneShot(winLevel);
                break;

        }
    }
}
