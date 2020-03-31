using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    //private int numberOfEnemies = 10;
    private int nextEnemy = 0;
    private bool waiting = false;

    public GameObject[] enemies;
    public GameObject instantiatingPoint;

    private GameObject previousEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        // spawn first enemy, call spawn()
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        // check if previous enemy died
        // or x time passed
        // if so spawn 
        StartCoroutine(SpawnCoroutine());

    }

    IEnumerator SpawnCoroutine()
    {
        if(waiting && previousEnemy!=null)
        {
            yield break;
        } 
        else
        {
            waiting = true;
            Debug.Log("Here");
            yield return new WaitForSeconds(5);
            Spawn();
            waiting = false;
        }
    }


    void Spawn()
    {
        //spawn an enemy
        previousEnemy = Instantiate(
            enemies[nextEnemy], 
            instantiatingPoint.GetComponent<Transform>().position, 
            Quaternion.identity
            );
        nextEnemy++;
        if(nextEnemy>9)
        {
            SceneManager.LoadScene(6);
        }
    }
}
