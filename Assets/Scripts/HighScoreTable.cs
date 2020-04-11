using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public Text[] Name;
    public Text[] Gpa;

    void OnGUI()
    {
        //PlayerPrefs.SetString("name", value);
        Name[0].text = PlayerPrefs.GetString("name1", "hsjgdjsagdshgdhgfhsd");
        Gpa[0].text = PlayerPrefs.GetString("gpa1", "3");

        Name[1].text = PlayerPrefs.GetString("name2", "Chris");
        Gpa[1].text = PlayerPrefs.GetString("gpa2", "4");

        Name[2].text = PlayerPrefs.GetString("name3", "Sushmita");
        Gpa[2].text = PlayerPrefs.GetString("gpa3", "3");

        Name[3].text = PlayerPrefs.GetString("name4", "Ishmeet");
        Gpa[3].text = PlayerPrefs.GetString("gpa4", "4");

        Name[4].text = PlayerPrefs.GetString("name5", "Sapana");
        Gpa[4].text = PlayerPrefs.GetString("gpa5", "3");

    }
}

