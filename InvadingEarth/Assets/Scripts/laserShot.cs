using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserShot : MonoBehaviour
{

    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (new Vector3(transform.position.x, transform.position.y + speed, transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(transform.parent.gameObject);
        }
        
    }
}
