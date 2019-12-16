using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool ispressed;
    // Start is called before the first frame update
    void Start()
    {
        ispressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(ispressed == false)
            {
                transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);
            }
        }
    }
}
