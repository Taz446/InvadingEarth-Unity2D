using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    private int difficulty;

    public void setEasy()
    {
        difficulty = 3;
        SceneManager.LoadScene("OpenScene");
    }

    public void setNormal()
    {
        difficulty = 2;
        SceneManager.LoadScene("OpenScene");
    }

    public void setHard()
    {
        difficulty = 1;
        SceneManager.LoadScene("OpenScene");
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }
}
