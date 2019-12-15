using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    // 카메라가 좀 더 부드럽게 움직이게 하기 위한 딜레이
    public float DelayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 위치에 따라서 바뀌는 카메라의 위치
        Vector3 FixedPos =
            new Vector3(
            target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ);

        // 플레이어가 떨어질 때를 제외하고는 카메라가 따라가도록 설정
        if(FixedPos.y >= 0)
        {
            transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
        }
        
    }
}
