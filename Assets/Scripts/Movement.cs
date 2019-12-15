using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    public GameObject center;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject rightUp;
    public int step = 9;
    private Vector3 lastPos;
    private bool ismoving;

    public float speed = (float)0.01;
    bool input = true;
    // Start is called before the first frame update
    void Start()
    {
        ismoving = false;
    }

    void FixedUpdate()
    {
        //Vector3 r = transform.TransformDirection(Vector3.right);

        //if (Physics.Raycast(center.transform.position + new Vector3(0.5f, 0, 0), r, 1))
        //    print("There is something in front of the object!");

        //if (Physics.CheckSphere(center.transform.position + new Vector3(0, -1.1f, 0), 0.1f))
        //{
        //    Debug.Log("뭔가 있음");
        //}

        CheckUnderBlock(center.transform.position + new Vector3(0, -1.1f, 0), 0.1f);
    }

    void CheckUnderBlock(Vector3 center, float radius)
    {
        Collider[] Colliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < Colliders.Length)
        {
            Debug.Log(Colliders[i].tag);
            //hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (input == true && ismoving == false)
        {
            if (Input.GetKey(KeyCode.UpArrow)){
                StartCoroutine("moveUp");
                input = false;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine("moveDown");
                input = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine("moveLeft");
                input = false;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine("moveRight");
                input = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine("moveRightUp");
                input = false;
            }
        }
    }

    IEnumerator moveUp()
    {
        for(int i=0; i<(90/step); i++)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            player.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
        //Debug.Log("up");
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            player.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            player.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            player.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveRightUp()
    {
        for (int i = 0; i < (90 / (step / 2f)); i++)
        {
            Physics.gravity = new Vector3(0, 0, 0);
            player.transform.RotateAround(rightUp.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed * 2f);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
    }

    public void CheckChangePosition()
    {
        if(lastPos != player.transform.localPosition)
        {
            ismoving = true;
            lastPos = player.transform.localPosition;
        }
        else
        {
            ismoving = false;
        }
    }
}
