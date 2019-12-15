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

    // 움직이고 난 후 아래 블록이 있는지 검사
    public bool isFloating;
    public float fallingSpeed = -0.1f;

    public float speed = (float)0.01;
    bool input;
    // Start is called before the first frame update
    void Start()
    {
        isFloating = false;
        input = true;
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

        CheckUnderBlock(center.transform.position + new Vector3(0, -1.2f, 0), 0.1f);
    }

    void CheckUnderBlock(Vector3 centerPoint, float radius)
    {
        Collider[] Colliders = Physics.OverlapSphere(centerPoint, radius);
        int i = 0;
        if (Colliders.Length == 0)
        {
            isFloating = true;
        }
        while (i < Colliders.Length)
        {
            Debug.Log(Colliders[i].tag);
            if(Colliders[i].tag == "Wall")
            {
                isFloating = false;
            }
            else
            {
                isFloating = true;
                if(input == true)
                {
                    center.transform.position = player.transform.position;
                    //StartCoroutine("fall");
                }
            }
            //hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (input == true && isFloating == false)
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

    IEnumerator fall()
    {
        for (int i = 0; i < (10); i++)
        {
            player.transform.TransformPoint(new Vector3(0, -0.1f, 0));
            //Physics.gravity = new Vector3(0, 0, 0);
            //player.transform.(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        center.transform.position = player.transform.position;
        input = true;
        //Debug.Log("up");
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
}
