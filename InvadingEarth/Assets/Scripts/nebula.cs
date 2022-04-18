using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nebula : MonoBehaviour
{

    public float speed = 0.003f;
    public GameObject[] nebulaPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (new Vector3(transform.position.x, transform.position.y - speed, transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Instantiate(nebulaPrefab[Random.Range(0, 3)], new Vector3(Random.Range(-5, 5), 10, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
