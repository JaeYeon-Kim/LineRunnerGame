using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject particle;
    float playerYPos;    // 플레이어의 position 저장 

    void Start()
    {
        // 초기의 플레이어의 위치 저장
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (!particle.activeInHierarchy)
            {
                particle.SetActive(true);
            }


            // 마우스 왼쪽 클릭시 혹은 모바일에서 터치할 경우 
            if (Input.GetMouseButtonDown(0))
            {
                // player position 변경
                playerYPos = -playerYPos;   // 현재 위치와 반대로 바꿔줌

                transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);


            }
        }

    }

    // 플레이어와 특정 물체가 trigger 할경우 호출 -> collision으로 정보가 들어옴 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // trigger한 객체가 장애물 일경우 
        if (collision.gameObject.tag == "Obstacle")
        {

            GameManager.instance.UpdateLives();

            // 플레이어와 장애물이 충돌했을 경우 카메라 흔들림 로직 추가 
            GameManager.instance.Shake();
        }
    }
}
