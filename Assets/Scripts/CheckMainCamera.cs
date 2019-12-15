using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMainCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 respawn;
    // Start is called before the first frame update
    void Start()
    {
        respawn = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckCamera(target))
        {
            Debug.Log("카메라 밖으로 나갔어요");
            target.transform.position = respawn;
        }
        //Debug.Log(CheckCamera(target));
    }

    // 기존의 카메라 밖으로 나간 플레이어 처리방식에는 문제가 좀 있어서 이 함수로 대체
    public bool CheckCamera(GameObject target)
    {
        //Camera cam = this.gameObject.GetComponent<Camera>();
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPoint = cam.WorldToViewportPoint(target.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        return onScreen;
    }
}
