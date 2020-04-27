using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyManager3 : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] instantiatingPoint;

    private int totalEnemiesSpawned = 0;
    public int totalEnemies = 10;
    public int totalEnemiesKilled = 0;

    public float timer = 0.0f;

    public int totalScore = 0;

    public double GPA;


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
        if(timer > 8.0f)  //10.0 in other levels
        {
            Spawn();
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

        
        //spawn an enemy
        GameObject enemy3 = Instantiate(
            enemies[totalEnemiesSpawned],
            instantiatingPoint[totalEnemiesSpawned].GetComponent<Transform>().position,
            Quaternion.identity
        );
        //calculate total score 
        totalScore += 30;
        enemy3.GetComponent<Enemy3>().enemyManager = this;
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
            SceneManager.LoadScene(12);
        }
        else
        {
            SceneManager.LoadScene(14);
        }
    }
}
