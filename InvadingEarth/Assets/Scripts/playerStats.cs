using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour
{

    public Text scoreTxt;
    public Text livesTxt;
    public Text weaponTxt;
    public Text resourcesTxt;

    private int score = 0;
    private int lives = 5;
    private int weaponLVL = 1;
    private int resources = 0;
    private int damage;
    private int gameDifficulty;

    public int maxHealth;
    public int health;
    public GameObject[] healthbar;
    Transform tr;
    Rigidbody2D rb;
    Collider2D cl;

    public Animator anim;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameDifficulty == 0)
        {
            gameDifficulty = 2;
        }

        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();

        scoreTxt.text = score.ToString();
        resourcesTxt.text = resources.ToString();
        weaponTxt.text = weaponLVL.ToString();
        livesTxt.text = lives.ToString();

        damage = weaponLVL * 5 * gameDifficulty;
        maxHealth *= gameDifficulty;

        health = maxHealth;

        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
        weaponTxt.text = "Weapon Level:  " + weaponLVL.ToString();
        livesTxt.text = lives.ToString();
        if (weaponLVL == 1)
        {
            resourcesTxt.text = resources.ToString() + "/750";
        }
        else if (weaponLVL == 2)
        {
            resourcesTxt.text = resources.ToString() + "/1500";
        }
        else
        {
            resourcesTxt.text = resources.ToString();
        }
    }

    public void resetPosition()
    {
        tr.position = new Vector3(0, -3, 0);
    }

    public void removeHealth(int dmg)
    {
        if (dmg < health)
        {
            health -= dmg;
            updateHealthbar();
        }
        else
        {
            playerDead();
        }
    }

    public void playerDead()
    {
        health = 0;
        updateHealthbar();
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        if (alive)
        {
            sounds.playExplosionSound();
        }
        alive = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        anim.SetBool("dead", true);
        cl.enabled = false;
        yield return new WaitForSeconds(1);
        anim.SetBool("dead", false);
        alive = true;
        cl.enabled = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        resetPlayer();
    }

    public void resetPlayer()
    {
        resetWeaponLVL();
        removeLives(1);
        setHealth(maxHealth);
        resetPosition();
        updateHealthbar();
    }

    public void updateHealthbar()
    {
        Vector3 temp1 = healthbar[0].transform.localScale;
        Vector3 temp2 = healthbar[1].transform.localScale;

        temp1.x = health / (float)maxHealth;
        temp2.x = health / (float)maxHealth;

        healthbar[0].transform.localScale = temp1;
        healthbar[1].transform.localScale = temp2;
    }

    public void setHealth(int h)
    {
        health = h;
    }

    public void addScore(int sc)
    {
        score += sc;
    }

    public void removeScore(int sc)
    {
        if ((score -= sc) > 0)
        {
            score -= sc;
        } else
        {
            score = 0;
        }
    }

    public void addLives(int lv)
    {
        lives += lv;
    }

    public void removeLives(int lv)
    {
        lives -= lv;
        if (lives <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void upgradeWeaponLVL()
    {
        if (weaponLVL < 3)
        {
            weaponLVL += 1;
            damage = weaponLVL * 5 * gameDifficulty;
        } 
    }

    public void resetWeaponLVL()
    {
        weaponLVL = 1;
        damage = weaponLVL * 5 * gameDifficulty;
    }

    public void addResources(int r)
    {
        sounds.playPickResourcesSound();
        resources += (r * gameDifficulty) / 2;
    }

    public void removeResources(int r)
    {
        if (r < resources)
        {
            resources -= r;
        }
        else
        {
            resources = 0;
        }
    }

    public int getScore()
    {
        return score;
    }

    public int getLives()
    {
        return lives;
    }

    public int getWeaponLVL()
    {
        return weaponLVL;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getResources()
    {
        return resources;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }

    void OnEnable()
    {
        gameDifficulty = PlayerPrefs.GetInt("difficulty");
    }

    public bool getState()
    {
        return alive;
    }
}
