using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreTable : MonoBehaviour
{
    public Text[] Name;
    public Text[] Gpa;
    public Text[] Level;

    void OnGUI()
    {
        Name[0].text = PlayerPrefs.GetString("name1", "Nishma");
        int score1 = PlayerPrefs.GetInt("score1", 0);
        Gpa[0].text = score1.ToString();
        //Level[0].text = PlayerPrefs.GetString("level1", "Freshmen");

        Name[1].text = PlayerPrefs.GetString("name2", "Chris");
        int score2 = PlayerPrefs.GetInt("score2", 0);
        Gpa[1].text = score2.ToString();
        //Level[1].text = PlayerPrefs.GetString("level2", "Freshmen");

        Name[2].text = PlayerPrefs.GetString("name3", "Sushmita");
        int score3 = PlayerPrefs.GetInt("score3", 0);
        Gpa[2].text = score3.ToString();
        //Level[2].text = PlayerPrefs.GetString("level3", "Sophomore");
        /*
        Name[3].text = PlayerPrefs.GetString("name4", "Ishmeet");
        Gpa[3].text = PlayerPrefs.GetString("gpa4", "4");
        Level[3].text = PlayerPrefs.GetString("level4", "Junior");

        Name[4].text = PlayerPrefs.GetString("name5", "Sapana");
        Gpa[4].text = PlayerPrefs.GetString("gpa5", "3");
        Level[4].text = PlayerPrefs.GetString("level5", "Senior");
        */


    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

