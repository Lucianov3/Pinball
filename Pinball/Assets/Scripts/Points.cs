using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Points : MonoBehaviour
{
    static public float points;
    static public float highScore;
    public TextMesh curPointsText;
    public TextMesh highPointsText;
    string stringText;

    private void Start()
    {
        Load();
    }
    private void Update()
    {
        stringText = "";
        for (int i = 0; i < 9-points.ToString().Length; i++)
        {
            stringText += "0";
        }
        stringText += points;
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
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/Highscore.69"); //you can call it anything you want
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
