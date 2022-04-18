using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneHolder : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartOpenScene()
    {
        SceneManager.LoadScene("OpenScene");
    }

    public void StartPreGame()
    {
        SceneManager.LoadScene("PreGameScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StartEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
