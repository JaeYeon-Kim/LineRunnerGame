using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
게임 내 작업을 관리하는 GameManager
*/
public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject spawner;
    public GameObject backgroundParticle;
    public static GameManager instance;
    public bool gameStarted = false;    // 게임이 시작되었는지 알기 위한 변수 

    Vector3 originalCamPos;

    [SerializeField] private GameObject player;           // player 변수 
    [SerializeField] private TextMeshProUGUI scoreText;       // 점수 UI 
    [SerializeField] private TextMeshProUGUI livesText;       // 생명력 UI 

    int lives = 2;  // 플레이어의 목숨 
    int score = 0;  // 플레이어의 score


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalCamPos = Camera.main.transform.position;        // 카메라의 원래 위치 
        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gameplayUI.SetActive(true);
        spawner.SetActive(true);
        backgroundParticle.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);        // 게임 오버 되었을 경웨 플레이어 비활성화 

        Invoke("ReloadLevel", 1.5f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        // 생명력이 0이 되었기 때문에 
        if (lives <= 0)
        {
            GameOver();
        }
        else    // 1개이상일 경우에는 라이프 감소
        {
            lives--;
            livesText.text = "Lives : " + lives;
            print("lives: " + lives);
        }


    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score;        // 점수 UI 적용 
        print("Score: " + score);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }


    // 카메라 흔들림 구현 
    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            // insideUnitCircle 변경이 1인 원 안에서 랜덤좌표 반환 -> 0.5를 곱해주면 반경이 0.5인 원 
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            // z값은 놔두고 x와 y만 랜덤값으로 
            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCamPos.z);

            yield return null;      // 현재 프레임이 완료될때 까지 대기 
        }

        Camera.main.transform.position = originalCamPos;
    }
}
