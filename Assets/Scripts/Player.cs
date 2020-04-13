using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //base bullet speed
    public float speed = 30;

    //reference to the bullet object that player will shoot
    public GameObject theBullet;

    void FixedUpdate()
    {
        //can use either a & d or left & right arrows to move
        float horzMove = Input.GetAxisRaw("Horizontal"); 

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //will fire a bullet when space is pressed
        if(Input.GetButtonDown("Jump"))
        {
            //creates a bullet at the players position which is transform.position
            //quaternion.identity will add bullets with no rotation
            Instantiate(theBullet, transform.position, Quaternion.Euler(0,0,-135));

            //plays a bullet fire sound when bullet is created
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.bulletFire);
        }
    }
    
}
