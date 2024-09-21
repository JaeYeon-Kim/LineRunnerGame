using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
게임 내 작업을 관리하는 GameManager
*/
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;    // 게임이 시작되었는지 알기 위한 변수 

    [SerializeField] private GameObject player;           // player 변수 

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;
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
}
