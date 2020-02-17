using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    //speed for the bullet
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to Rigidbody for the bullet
        rigidBody = GetComponent<Rigidbody2D>();

        //when bullet is called it will down at the speed
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

        //if bullet hits player then destroy enemyBullet and Player
        if(col.gameObject.tag == "Player")
        {
            //Play sound when player hit
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.playerDies);

            //Destroy the player
            Destroy(col.gameObject);

            //Destroy the bullet
            Destroy(gameObject);

        }
    }

    //when bullet isn't used will call this and make invisible
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
