using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_level2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //will go to next level when space is pressed
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(4);
        }
    }
}
