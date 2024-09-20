using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerYPos;    // 플레이어의 position 저장 
    // Start is called before the first frame update
    void Start()
    {
        // 초기의 플레이어의 위치 저장
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        // 마우스 왼쪽 클릭시 혹은 모바일에서 터치할 경우 
        if (Input.GetMouseButtonDown(0))
        {
            // player position 변경
            playerYPos = -playerYPos;   // 현재 위치와 반대로 바꿔줌

            transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);

            
        }
    }
}
