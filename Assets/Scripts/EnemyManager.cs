using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject instantiatingPoint;

    private int totalEnemiesSpawned = 0;
    public int totalEnemies = 9;
    public int totalEnemiesKilled = 0;

    public float timer = 0.0f;

    public int totalScore = 0;

    public int percentage;
    public int GPA;

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
        if(timer > 10.0f)
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
        GameObject enemy = Instantiate(
            enemies[totalEnemiesSpawned],
            instantiatingPoint.GetComponent<Transform>().position,
            Quaternion.identity
        );
        //calculate total score 
        totalScore += 15;
        enemy.GetComponent<Enemy>().enemyManager = this;
        totalEnemiesSpawned++;
    }
    
    //if all enemies are dead, check for score and go to next level if gpa 2 or higher
    public void nextLevel()
    {
        //find the text Score UI component
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();

        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);

        //calculate percentage
        percentage = (score / totalScore) * 100;
        if(percentage>=85)
        {
            GPA = 4;
        }
        else if (percentage >= 70)
        {
            GPA = 3;
        }
        else if (percentage >= 55)
        {
            GPA = 2;
        }
        else 
        {
            GPA = 1;
        }

        if(GPA>=2)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }
}
