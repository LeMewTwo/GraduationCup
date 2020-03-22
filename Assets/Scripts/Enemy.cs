using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //base speed for enemy
    public float speed = 10;

    public Rigidbody2D rigidBody;

    //reference to enemyBullet GameObject
    public GameObject enemyBullet;

    //min, max, base firing rate time for bullets
    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 2.0f;
    public float baseFireWaitTime = 2.0f;

    public static System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
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
        position.y -= 1;
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

        if(col.gameObject.tag == "Bullet")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);
            Destroy(gameObject);
        }

    }

    //enemys will fire bullets at random times
    void FixedUpdate()
    {
        if(Time.time > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(enemyBullet, transform.position, Quaternion.identity);
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
