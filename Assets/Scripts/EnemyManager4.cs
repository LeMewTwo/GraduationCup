using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyManager4 : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] instantiatingPoint;

    private int totalEnemiesSpawned = 0;
    public int totalEnemies = 15;
    public int totalEnemiesKilled = 0;

    public float timer = 0.0f;
    public float timeout = 0.0f;

    public int totalScore = 0;

    public float GPA;
    public TimeScript timescript;

    // Start is called before the first frame update
    void Start()
    {
        // spawn first enemy, call spawn()
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        // check if x time passed
        // if so spawn 
        if(totalEnemiesSpawned >= totalEnemies)
        {
            //all enemy spawned so do not instantiate new enemy
            return;
        }
        
        timer += Time.deltaTime;
        timeout += Time.deltaTime;
        if (timer > 10.0f)
        {
            Spawn();
        }

        if(timeout > 59.9f)
        {
            nextLevel();
            return;
        }
        
    }

    /*
    IEnumerator SpawnCoroutine()
    {   
        yield return new WaitForSeconds(10);
        Spawn();
    }
    */

    public void SetTimer(float newTimer)
    {
        timer = newTimer;
    }

    //spawn enemies
    public void Spawn()
    {
        timer = 0.0f;
        //if all enemies are spawned do nothing
        if(totalEnemiesSpawned >= totalEnemies)
        {
            return;
        }
        if (timeout>59.9f)
        {
            nextLevel();
            return;
        }


        //spawn an enemy
        GameObject enemy4 = Instantiate(
            enemies[totalEnemiesSpawned],
            instantiatingPoint[totalEnemiesSpawned].GetComponent<Transform>().position,
            Quaternion.identity
        );
        //calculate total score 
        totalScore += 30;
        enemy4.GetComponent<Enemy4>().enemyManager = this;
        totalEnemiesSpawned++;
    }
    
    //if all enemies are dead, check for score and go to next level if gpa 2 or higher
    public void nextLevel()
    {
        //find the text Score UI component
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();

        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);

        //calculate GPA
        GPA = ((score*1.0f) / totalScore) * 4.0f;
        GPA = (float)Math.Round(GPA * 100f) / 100f;
        Debug.Log(GPA);

        if(GPA>=2)
        {
            SceneManager.LoadScene(15);
        }
        else
        {
            SceneManager.LoadScene(17);
        }
    }
}
