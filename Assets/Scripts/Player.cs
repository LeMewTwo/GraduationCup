using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 30;

    public GameObject theBullet;

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal"); //can use either a & d or left & right arrows to move

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
        }
    }
}
