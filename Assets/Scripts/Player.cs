using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 사용안함
    // 플레이어가 카메라 시점에서 벗어났을 때
    //private void OnBecameInvisible()
    //{
    //    // Destroy(this.gameObject);
    //    Debug.Log("안보여");
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("바닥에 닿음");
        }
    }
}
