using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int highscore;
    public new string name;
    public InputField nameInput;


    void Awake()
	{
        makeInstance();
        PlayerPrefs.SetInt("Highscore", 0);
	}

    void Update()
	{
        highscore = PlayerPrefs.GetInt("Highscore");
	}
    /*
    void StoreHighScore()
	{

	}
    */
    public void setName()
	{
        name = nameInput.text;
        PlayerPrefs.SetString("name", name);
	}

    private void makeInstance()
	{
        if(instance != null)
		{
            Destroy(gameObject);
		}
		else
		{
            instance = this;
            DontDestroyOnLoad(gameObject);
		}
	}

}
