using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject center;
    public GameObject forward;
    public GameObject backward;
    public GameObject left;
    public GameObject right;
    public GameObject forwardUp;
    public GameObject backwardUp;
    public GameObject leftUp;
    public GameObject rightUp;
    public int step = 9;
    public Vector3 gravity;
    public float fallingSpeed = -0.1f;
    public float speed = (float)0.01;

    public static bool isGameOver;

    bool input;         // 플레이어의 이동모션이 끝났는지 체크
    bool ismoving;      // 큐브가 움직이고 있는지 체크
    bool isFloating;    // 움직이고 난 후 아래 블록이 있는지 검사
    float timer;        // ismoving 체크에 딜레이를 걸어줌
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        isFloating = false;
        input = true;
        ismoving = false;
        isGameOver = false;
    }

    void FixedUpdate()
    {
        CheckChangePosition();
        CheckUnderBlock(center.transform.position + new Vector3(0, -1.2f, 0), 0.1f);

        if (input == true)
        {
            center.transform.position = player.transform.position;
        }
        
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
            // Debug.Log(Colliders[i].tag);
            if(Colliders[i].tag == "Wall")
            {
                isFloating = false;
            }
            else if(Colliders[i].tag == "EndPoint")
            {
                isGameOver = true;
                isFloating = true;
            }
            else
            {
                isFloating = true;
            }
            i++;
        }
    }

    bool CheckBlock(Vector3 centerPoint, float radius)
    {
        bool isOverlap = false;
        Collider[] Colliders = Physics.OverlapSphere(centerPoint, radius);
        int i = 0;
        if (Colliders.Length == 0)
        {
            isOverlap = false;
        }
        while (i < Colliders.Length)
        {
            // Debug.Log(Colliders[i].tag);
            if (Colliders[i].tag == "Wall")
            {
                isOverlap = true;
            }
            else
            {
                isOverlap = false;
            }
            i++;
        }
        return isOverlap;
    }

    // Update is called once per frame
    void Update()
    {
        if (input == true && isFloating == false && ismoving == false)
        {
            if (Input.GetKey(KeyCode.UpArrow)){
                // 동시 키입력을 방지하기 위해 한번 더 input을 체크
                if(input == true)
                {
                    input = false;
                    StartCoroutine("moveUp");
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (input == true)
                {
                    input = false;
                    StartCoroutine("moveDown");
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (input == true)
                {
                    input = false;
                    StartCoroutine("moveLeft");
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (input == true)
                {
                    input = false;
                    StartCoroutine("moveRight");
                }
            }
        }
    }

    IEnumerator moveLeft()
    {
        if (CheckBlock(center.transform.position + new Vector3(0, 0, 1.2f), 0.1f))
        {
            if (CheckBlock(center.transform.position + new Vector3(0, 2.0f, 1.2f), 0.1f))
            {
                for (int i = 0; i < (90 / step); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(forwardUp.transform.position, Vector3.right, step);
                    yield return new WaitForSeconds(speed);
                }
            }
            else
            {
                for (int i = 0; i < (90 / (step / 2f)); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(forwardUp.transform.position, Vector3.right, step);
                    yield return new WaitForSeconds(speed * 2f);
                }
            }
        }
        else
        {
            for (int i = 0; i < (90 / step); i++)
            {
                Physics.gravity = new Vector3(0, 0, 0);
                player.transform.RotateAround(forward.transform.position, Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
        }
        
        Physics.gravity = gravity;
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        if (CheckBlock(center.transform.position + new Vector3(0, 0, -1.2f), 0.1f))
        {
            if (CheckBlock(center.transform.position + new Vector3(0, 2.0f, -1.2f), 0.1f))
            {
                for (int i = 0; i < (90 / step); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(backwardUp.transform.position, Vector3.left, step);
                    yield return new WaitForSeconds(speed);
                }
            }
            else
            {
                for (int i = 0; i < (90 / (step / 2f)); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(backwardUp.transform.position, Vector3.left, step);
                    yield return new WaitForSeconds(speed * 2f);
                }
            }
        }
        else
        {
            for (int i = 0; i < (90 / step); i++)
            {
                Physics.gravity = new Vector3(0, 0, 0);
                player.transform.RotateAround(backward.transform.position, Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
        }
        
        Physics.gravity = gravity;
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveDown()
    {
        if (CheckBlock(center.transform.position + new Vector3(-1.2f, 0, 0), 0.1f))
        {
            if (CheckBlock(center.transform.position + new Vector3(-1.2f, 2.0f, 0), 0.1f))
            {
                for (int i = 0; i < (90 / step); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(leftUp.transform.position, Vector3.forward, step);
                    yield return new WaitForSeconds(speed);
                }
            }
            else
            {
                for (int i = 0; i < (90 / (step / 2f)); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(leftUp.transform.position, Vector3.forward, step);
                    yield return new WaitForSeconds(speed * 2f);
                }
            }            
        }
        else
        {
            for (int i = 0; i < (90 / step); i++)
            {
                Physics.gravity = new Vector3(0, 0, 0);
                player.transform.RotateAround(left.transform.position, Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
        }
        
        Physics.gravity = gravity;
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveUp()
    {
        if(CheckBlock(center.transform.position + new Vector3(1.2f, 0, 0), 0.1f))
        {
            if (CheckBlock(center.transform.position + new Vector3(1.2f, 2.0f, 0), 0.1f))
            {
                for (int i = 0; i < (90 / step); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(rightUp.transform.position, Vector3.back, step);
                    yield return new WaitForSeconds(speed);
                }
            }
            else
            {
                for (int i = 0; i < (90 / (step / 2f)); i++)
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                    player.transform.RotateAround(rightUp.transform.position, Vector3.back, step);
                    yield return new WaitForSeconds(speed * 2f);
                }
            }
        }
        else
        {
            for (int i = 0; i < (90 / step); i++)
            {
                Physics.gravity = new Vector3(0, 0, 0);
                player.transform.RotateAround(right.transform.position, Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
        }
        
        Physics.gravity = gravity;
        center.transform.position = player.transform.position;
        input = true;
    }

    public void CheckChangePosition()
    {
        timer += Time.deltaTime;
        // 0.02초 전과 현재 위치를 비고
        if (timer >= 0.02f)
        {
            if (lastPos != player.transform.localPosition)
            {
                ismoving = true;
                lastPos = player.transform.localPosition;
            }
            else
            {
                ismoving = false;
            }
            timer = 0f;
        }
    }
}
