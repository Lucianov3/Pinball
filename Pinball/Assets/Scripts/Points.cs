﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Points : MonoBehaviour
{
    static public float score;
    static public float highScore;
    public float newHighscore;
    public TextMesh curPointsText;
    public TextMesh highPointsText;
    string stringText;

    private void Start()
    {
        if (newHighscore == 0)
        {
            Load();
        }
        else
        {
            highScore = newHighscore;
        }
    }
    private void Update()
    {
        stringText = "";
        for (int i = 0; i < 9-score.ToString().Length; i++)
        {
            stringText += "0";
        }
        stringText += score;
        curPointsText.text = stringText;

        stringText = "";
        for (int i = 0; i < 9 - highScore.ToString().Length; i++)
        {
            stringText += "0";
        }
        stringText += highScore;
        highPointsText.text = stringText;
    }

    

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Highscore.69");
        bf.Serialize(file, highScore);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Highscore.69"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Highscore.69", FileMode.Open);
            highScore = (float)bf.Deserialize(file);
            file.Close();
        }
    }
}
