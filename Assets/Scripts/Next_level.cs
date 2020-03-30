using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_level : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //will fire a bullet when space is pressed
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
