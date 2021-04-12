using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagUp : MonoBehaviour
{
    public static bool flagUp = false;
    private bool hasBeen = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (flagUp && !hasBeen)
        {
            Debug.Log("uppp");
            gameObject.transform.Translate(0, 1.6f, 0);
            hasBeen = true;
        }
    }

}
