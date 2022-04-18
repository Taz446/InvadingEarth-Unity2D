using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class resources : MonoBehaviour
{
    GameObject player;

    public float speed = 0.0075f;
    public GameObject[] spritePrefab;
    Renderer ren;
    Collider2D cl;

    public int rsc;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        cl = GetComponent<Collider2D>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (new Vector3(transform.position.x, transform.position.y - speed, transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            player.GetComponent<playerStats>().addResources(rsc);
            StartCoroutine(coroutine());
        }
        else if (other.gameObject.name == "botCollider")
        {
            Instantiate(spritePrefab[UnityEngine.Random.Range(0, 2)], new Vector3(UnityEngine.Random.Range(-5, 5), 10, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }


    IEnumerator coroutine()
    {
        ren.enabled = false;
        cl.enabled = false;

        yield return new WaitForSeconds(6);

        ren.enabled = true;
        cl.enabled = true;

        Instantiate(spritePrefab[UnityEngine.Random.Range(0, 2)], new Vector3(UnityEngine.Random.Range(-5, 5), 10, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}