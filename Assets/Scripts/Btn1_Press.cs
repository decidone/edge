using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn1_Press : MonoBehaviour
{
    bool ispressed;
    public GameObject blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        ispressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ispressed == false)
            {
                transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);

                StartCoroutine(MovingBlocks(blocks.transform.position, new Vector3(blocks.transform.position.x - 4,
                    blocks.transform.position.y, blocks.transform.position.z + 4), 30));
                ispressed = true;
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (ispressed == false)
    //        {
    //            transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);

    //            StartCoroutine(MovingBlocks(blocks.transform.position, new Vector3(blocks.transform.position.x - 4,
    //                blocks.transform.position.y, blocks.transform.position.z + 4), 30));
    //            ispressed = true;
    //        }
    //    }
    //}

    // 블럭들만 움직임
    IEnumerator MovingBlocks(Vector3 before, Vector3 after, int time)
    {
        Vector3 diff;
        diff = after - before;
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < time; i++)
        {
            blocks.transform.position
                = new Vector3(blocks.transform.position.x, blocks.transform.position.y, blocks.transform.position.z + (diff.z / time));
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < time; i++)
        {
            blocks.transform.position
                = new Vector3(blocks.transform.position.x + (diff.x / time), blocks.transform.position.y, blocks.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < time; i++)
        {
            blocks.transform.position
                = new Vector3(blocks.transform.position.x, blocks.transform.position.y + (diff.y / time), blocks.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        //blocks.transform.position = after;

    }
}
