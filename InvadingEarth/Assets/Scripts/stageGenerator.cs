using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageGenerator : MonoBehaviour
{

    public GameObject[] spritePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(5);

        Instantiate(spritePrefab[UnityEngine.Random.Range(0, 2)], new Vector3(UnityEngine.Random.Range(-5, 5), 10, 0), Quaternion.identity);
    }
}
