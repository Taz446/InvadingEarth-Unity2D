using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars : MonoBehaviour
{

    public float speed = 0.005f;
    public GameObject starsPrefab;

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
        Instantiate(starsPrefab, new Vector3(0, 10, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
