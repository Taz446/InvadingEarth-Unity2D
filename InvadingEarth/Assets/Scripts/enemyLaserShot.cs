using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaserShot : MonoBehaviour
{
    GameObject player;

    public float speed = 0.035f;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
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
            player.GetComponent<playerStats>().removeHealth(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "botCollider")
        {
            Destroy(gameObject);
        }


    }
}
