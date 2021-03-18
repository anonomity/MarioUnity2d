using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data_Management : MonoBehaviour
{
    public static DataManagement datamanagement;

    public int highScore;

    void Awake () {
        if(datamanagement == null){
            DontDestroyOnLoad (gameObject);
            datamanagement = this;
        } else if(datamanagement != this){
            Destroy (gameObject);
        }
    }

    public void SaveData() {

    }

    public void LoadDate() {
        
    }

}
