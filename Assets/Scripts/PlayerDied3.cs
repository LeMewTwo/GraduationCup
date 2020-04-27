﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied3 : MonoBehaviour
{

    //loads Game screen when play Again button is pressed
    public void PlayAgain()
    {
        SceneManager.LoadScene(4);
    }

    //loads MainMenu when Main Menu button is pressed
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

}
