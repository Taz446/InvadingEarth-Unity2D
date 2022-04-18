using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endScene : MonoBehaviour
{
    private int score;
    public Text scoreTxt;


    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "Your Score: " + score;
    }

    void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
    }
}
