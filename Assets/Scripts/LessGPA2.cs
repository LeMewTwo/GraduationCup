﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessGPA2 : MonoBehaviour
{
    //if pressed playAgain button, go to Level 1 again
    public void PlayAgain()
    {
        SceneManager.LoadScene(3);
    }

    //if Main Menu button pressed, go to Menu
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
