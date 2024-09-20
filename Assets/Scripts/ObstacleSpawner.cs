using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    // 장애물을 저장할 수 있는 배열 생성 
    public GameObject[] obstacles;

    Vector3 spawnPos;       // 장애물 생성 위치 
    public float spawnRate;


    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;  // 장애물 생성기 위치가 생성되는 장애물의 위치 

        // Spawn();

        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    // 장애물 생성 
    void Spawn()
    {
        int randObstacle = UnityEngine.Random.Range(0, obstacles.Length);

        Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);

    }
}
