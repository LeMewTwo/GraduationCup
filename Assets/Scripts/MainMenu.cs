using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject cup;
    private float counter;

    private int speed;

    /*public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;*/

    //loads Game screen when start button is pressed
    public void newGame()
    {
        SceneManager.LoadScene(2);
    }

    //Loads LeaderBoard screen
    public void LeaderBoard()
    {
        SceneManager.LoadScene(1);
    }

    //Blinking of Graduation cup
    void Start()
    {
        counter = 0;
        speed = 3;
    }
    //Blinking of Graduation cup
    void Update()
    {

        counter += Time.deltaTime * speed;
        if (((int)counter) % 2 == 0)
        {
            cup.SetActive(true);
        }
        else
        {
            cup.SetActive(false);
        }
        if (counter > 10000.0f)
            counter = 0f;
    }

    //To exit the game
    public void exitGame()
    {
        Debug.Log("Exiting!");
        Application.Quit();
    }

    //code to show loading level
    /*public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = (int)(progress * 100f) + "%";

            yield return null;
        }
    }*/
}
