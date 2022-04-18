using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    GameObject player;

    public GameObject spritePrefab;

    public GameObject[] enemyGroups;
    public GameObject[] endlessEnemyGroupsEasy;
    public GameObject[] endlessEnemyGroupsHard;
    int i = 0;

    bool endless = false;
    bool hard = false;

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Instantiate(enemyGroups[i], new Vector3(0, 10, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || timer > 3000)
        {
            if (player.GetComponent<playerStats>().getScore() > 8000 && !hard)
            {
                hard = true;
            }
            spawnNext();
            timer = 0;
        }
    }

    void FixedUpdate()
    {
        timer++;
    }

    void spawnNext()
    {
        if (!endless)
        {
            if (i < enemyGroups.Length - 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("EnemyGroup"));
                i++;
                Instantiate(enemyGroups[i], new Vector3(0, 10, 0), Quaternion.identity);
            }
            else
            {
                endless = true;
            }
        }
        else
        {
            if (!hard)
            {
                Destroy(GameObject.FindGameObjectWithTag("EnemyGroup"));
                Instantiate(endlessEnemyGroupsEasy[UnityEngine.Random.Range(0, 5)], new Vector3(0, 10, 0), Quaternion.identity);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("EnemyGroup"));
                Instantiate(endlessEnemyGroupsHard[UnityEngine.Random.Range(0, 4)], new Vector3(0, 10, 0), Quaternion.identity);
            }
        }
    }
}
