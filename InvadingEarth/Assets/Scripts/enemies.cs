using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public int health;
    public GameObject laserPrefab;
    public float fireRate;
    public int score;

    GameObject player;

    Transform tr;
    Collider2D col;
    Rigidbody2D rb;

    public float speed = 2.0f;
    public GameObject[] waypoints;

    bool setup = false;
    bool direction = false;
    public bool isStatic = false;
    int i = 0;

    bool dead = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        StartCoroutine(coroutine());

        player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody2D>();

        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var movementThisFrame = speed * Time.deltaTime;

        if (!setup)
        {
            var targetPosition = new Vector3(waypoints[i].transform.position.x, waypoints[i].transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                setup = true;
                col.enabled = true;
                i++;
            }
        }
        else if (!dead)
        {
            if (!isStatic)
            {
                moveNext();
            }
        }
    }

    void moveNext()
    {
        var movementThisFrame = speed * Time.deltaTime;

        var targetPosition = new Vector3(waypoints[i].transform.position.x, waypoints[i].transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

        if (transform.position == targetPosition)
        {
            if (i == 1)
            {
                direction = !direction;
            }
            else if (i == (waypoints.Length - 1))
            {
                direction = !direction;
            }

            if (direction)
            {
                i++;
            }
            else
            {
                i--;
            }
        }
    }

    void ShootLaser()
    {
        sounds.playLaserSound(0.2f);
        Instantiate(laserPrefab, new Vector3(tr.position.x, tr.position.y, 0), Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerLaser")
        {
            removeHealth(player.GetComponent<playerStats>().getDamage());
        }
    }

    public void addHealth(int h)
    {
        health += h;
    }

    public void removeHealth(int h)
    {
        if (h < health)
        {
            health -= h;
        }
        else
        {
            if (!dead)
            {
                player.GetComponent<playerStats>().addScore(score);
            }
            CancelInvoke();
            StartCoroutine(deathCoroutine());
        }
    }

    IEnumerator coroutine()
    {
        while (!setup)
        {
            yield return new WaitForSeconds(0.5f);
        }
        InvokeRepeating("ShootLaser", 0, fireRate);
    }

    IEnumerator deathCoroutine()
    {
        if (!dead)
        {
            sounds.playExplosionSound();
        }
        dead = true;
        col.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
