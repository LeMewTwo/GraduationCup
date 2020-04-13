using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    //base speed for enemy
    public float speed = 16;

    public Rigidbody2D rigidBody;

    //reference to enemyBullet GameObject
    public GameObject enemyBullet;
    public GameObject Books;
    private int hit = 0;
    //public GameObject instantiatingPoint;
    //min, max, base firing rate time for bullets
    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 4.0f;
    public float baseFireWaitTime = 1.0f;

    public float minFireBookRateTime = 3.0f;
    public float maxFireBookRateTime = 12.0f;
    public float baseFireBookWaitTime;


    private float instantiateTime = 0.0f;

    public static System.Random rand = new System.Random();

    public EnemyManager2 enemyManager2;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTime = Time.time;
        rigidBody = GetComponent<Rigidbody2D>();

        //random starting direction and speed
        if (rand.Next(0, 2) == 0)
        {
            rigidBody.velocity = new Vector2(1, 0) * speed;
        }
        else
        {
            rigidBody.velocity = new Vector2(-1, 0) * speed;
        }

        //random fire wait time for each enemy
        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
        baseFireBookWaitTime = Random.Range(minFireBookRateTime, maxFireBookRateTime);

    }

    //on every update
    void Update()
    {
        //find the text Score UI component
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();

        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);

        //covert the int score back into a string to update the text UI
        scoreTextComp.text = score.ToString();

        if (score < 0)
        {
            SceneManager.LoadScene(10);
        }

    }

    //Turn in opposite direction for enemy object
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    //Move down after hitting wall
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 2;
        transform.position = position;
    }

    //when enemy hits wall, it will switch direction and call movedown
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }

        if(col.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        if (col.gameObject.name == "BottomWall")
        {
            //Turn(1);
            //MoveDown();
            enemyManager2.totalEnemiesKilled++;
            enemyManager2.SetTimer(9.0f);
            Destroy(gameObject);
            if (enemyManager2.totalEnemiesKilled == 9)
            {
                enemyManager2.nextLevel();
            }
        }


    }

    public void Die()
    {
        //destroy bullet
        hit++;
        if (hit == 6)
        {
            enemyManager2.totalEnemiesKilled++;
            enemyManager2.SetTimer(9.0f);
            Destroy(gameObject);
            if (enemyManager2.totalEnemiesKilled == 9)
            {
                enemyManager2.nextLevel();
            }
        }
    }

    //enemys will fire bullets at random times
    void FixedUpdate()
    {
        if((Time.time - instantiateTime )> baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(enemyBullet, transform.position, Quaternion.identity);

        }

        if ((Time.time - instantiateTime) > baseFireBookWaitTime)
        {
            baseFireBookWaitTime = baseFireBookWaitTime + Random.Range(minFireBookRateTime, maxFireBookRateTime);

            Instantiate(Books, transform.position, Quaternion.identity);
            enemyManager2.totalScore+=5;

        }


    }

    //if the enemy ever collides with the player they both will be destroyed
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            Destroy(gameObject);

            Destroy(col.gameObject);
        }
    }

}
