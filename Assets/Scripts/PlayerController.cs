using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // 플레이어와 특정 물체가 trigger 할경우 호출 -> collision으로 정보가 들어옴 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // trigger한 객체가 장애물 일경우 
        if (collision.gameObject.tag == "Obstacle")
        {
            // // 장애물과 충돌했을 경우에 현재 게임 Scene을 재로드
            // SceneManager.LoadScene("Game");

            // GameManager.instance.GameOver();    // GameManager의 GameOver 호출 

            GameManager.instance.UpdateLives();
        }
    }
}
