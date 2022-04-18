using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    GameObject player;

    public GameObject[] laserPrefab;
    Transform tr;

    Rigidbody2D rb;

    public float moveSpeed = 7.5f;
    float inputH, inputV;
    Vector2 motion;

    bool cd = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        tr = GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<playerStats>().getState())
        {
            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");

            motion.x = inputH;
            motion.y = inputV;

            if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!cd)
                {
                    cd = true;
                    StartCoroutine(coroutine());
                }

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GetComponent<playerStats>().getWeaponLVL() == 1)
                {
                    if (GetComponent<playerStats>().getResources() >= 750)
                    {
                        GetComponent<playerStats>().removeResources(750);
                        GetComponent<playerStats>().upgradeWeaponLVL();
                    }
                }
                else if (GetComponent<playerStats>().getWeaponLVL() == 2)
                {
                    if (GetComponent<playerStats>().getResources() >= 1500)
                    {
                        GetComponent<playerStats>().removeResources(1500);
                        GetComponent<playerStats>().upgradeWeaponLVL();
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = motion * moveSpeed;   
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GetComponent<playerStats>().playerDead();
        } 
    }

    IEnumerator coroutine()
    {
        sounds.playLaserSound(0.5f);
        Instantiate(laserPrefab[GetComponent<playerStats>().getWeaponLVL() - 1], new Vector3(tr.position.x, tr.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        cd = false;
    }
}
