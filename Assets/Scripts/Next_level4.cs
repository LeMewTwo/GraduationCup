using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_level4 : MonoBehaviour
{

    void Start()
	{
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();

        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);
        score = PlayerPrefs.GetInt("Highscore");
        string name = PlayerPrefs.GetString("name");

        string name1 = PlayerPrefs.GetString("name1");
        string name2 = PlayerPrefs.GetString("name2");
        string name3 = PlayerPrefs.GetString("name3");
        int score1 = PlayerPrefs.GetInt("score1");
        int score2 = PlayerPrefs.GetInt("score2");
        int score3 = PlayerPrefs.GetInt("score3");

        scoreTextComp.text = score.ToString();

        if(score > score1)
		{
            PlayerPrefs.SetString("name1", name);
            PlayerPrefs.SetString("name3", name2);
            PlayerPrefs.SetString("name2", name1);
            PlayerPrefs.SetInt("score1", score);
            PlayerPrefs.SetInt("score3", score2);
            PlayerPrefs.SetInt("score2", score1);
        }
        else if(score > score2)
		{
            
            PlayerPrefs.SetString("name2", name);
            PlayerPrefs.SetString("name3", name2);
            PlayerPrefs.SetInt("score2", score);
            PlayerPrefs.SetInt("score3", score2);
        }
        else if(score > score3)
		{
            PlayerPrefs.SetString("name3", name);
            PlayerPrefs.SetInt("score3", score);
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
