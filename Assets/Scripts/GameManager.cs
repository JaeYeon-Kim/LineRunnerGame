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

    [SerializeField] private GameObject player;           // player 변수 
    [SerializeField] private TextMeshProUGUI scoreText;       // 점수 UI 
    [SerializeField] private TextMeshProUGUI livesText;       // 생명력 UI 

    int lives = 2;  // 플레이어의 목숨 
    int score = 0;  // 플레이어의 score


    private void Awake()
    {
        instance = this;
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
}
