using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public string name;
    public InputField nameInput;


    void Awake()
	{
        makeInstance();
	}

    public void setName()
	{
        name = nameInput.text;
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
