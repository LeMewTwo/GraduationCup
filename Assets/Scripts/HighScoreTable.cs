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
        //PlayerPrefs.SetString("name", value);
        Name[0].text = PlayerPrefs.GetString("name1", "Nishma");
        Gpa[0].text = PlayerPrefs.GetString("gpa1", "3");
        Level[0].text = PlayerPrefs.GetString("level1", "Freshmen");

        Name[1].text = PlayerPrefs.GetString("name2", "Chris");
        Gpa[1].text = PlayerPrefs.GetString("gpa2", "4");
        Level[1].text = PlayerPrefs.GetString("level2", "Freshmen");

        Name[2].text = PlayerPrefs.GetString("name3", "Sushmita");
        Gpa[2].text = PlayerPrefs.GetString("gpa3", "3");
        Level[2].text = PlayerPrefs.GetString("level3", "Sophomore");

        Name[3].text = PlayerPrefs.GetString("name4", "Ishmeet");
        Gpa[3].text = PlayerPrefs.GetString("gpa4", "4");
        Level[3].text = PlayerPrefs.GetString("level4", "Junior");

        Name[4].text = PlayerPrefs.GetString("name5", "Sapana");
        Gpa[4].text = PlayerPrefs.GetString("gpa5", "3");
        Level[4].text = PlayerPrefs.GetString("level5", "Senior");

    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

