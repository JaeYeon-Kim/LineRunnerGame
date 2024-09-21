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

        int randomSpot = UnityEngine.Random.Range(0, 2);        // 0 = top, 1 = bottom

        spawnPos = transform.position;

        if (randomSpot < 1)
        {
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }
        else
        {
            // 현재 오브젝트의 y축을 음수로 변경 
            spawnPos.y = -transform.position.y;

            // 두개 짜리 장애물 일경우 
            if (randObstacle == 1)
            {
                // x축의 위치를 1증가 
                spawnPos.x += 1;
            }
            else if (randObstacle == 2)
            {
                // x축의 위치를 2증가 
                spawnPos.x += 2;
            }


            GameObject obs = Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180);
        }


        // GameObject cloneObstacle = 

        // if (randomSpot == 1)
        // {
        //     cloneObstacle.transform.position = new Vector3(cloneObstacle.transform.position.x, -cloneObstacle.transform.position.y, cloneObstacle.transform.position.z);
        //     cloneObstacle.transform.Rotate(0, 0, 180);

        //     if (randObstacle >= 1)
        //     {
        //         cloneObstacle.transform.position = new Vector3(cloneObstacle.transform.position.x + randObstacle, cloneObstacle.transform.position.y, cloneObstacle.transform.position.z);
        //     }
        // }
    }
}
