using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    //speed for the bullet
    public float speed = 30;
    public PlayerDied playerdied;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to Rigidbody for the bullet
        rigidBody = GetComponent<Rigidbody2D>();

        //when bullet is called it will go down at the speed
        rigidBody.velocity = Vector2.down * speed;
    }

    //when bullet hits something will call, object hit is passed as a parameter
    void OnTriggerEnter2D(Collider2D col)
    {
        //if enemyBullet hits a wall it will destroy the bullet
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        //if bullet hits player then destroy enemyBullet and decrease score
        if(col.gameObject.tag == "Player")
        {
            //Play sound when player hit
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.playerDies);

            //Destroy the player
            //Destroy(col.gameObject);
            //Decrease Score by 10
            DecreaseScoreText();

            //Destroy the bullet
            Destroy(gameObject);

        }
    }

    //decreased the score in the text UI when called
    void DecreaseScoreText()
    {
        //find the text Score UI component
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();

        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);

        score -= 20;

        //covert the int score back into a string to update the text UI
        scoreTextComp.text = score.ToString();

        /*if(score<0)
        {
            SceneManager.LoadScene(7);
        }*/
    }

    //when bullet isn't used will call this and make invisible
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
