using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPrefabs; // 여러 종류의 오브젝트 리스트

    float minSpawnTime = 0f;  // 최소 생성 시간
    float maxSpawnTime = 5f;  // 최대 생성 시간
    float spawnOffset = 100f; // 화면 바깥 생성 거리 (픽셀)

    Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main; // 카메라 변경될 수도 있음 
        StartCoroutine(SpawnMonsterRoutine());
    }


    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
            
            SpawnMonster();
        }
    }


    void SpawnMonster()
    {
        if (mainCamera == null || monsterPrefabs.Count == 0) { Debug.LogError("mainCamera == null || monsterPrefabs.Count == 0"); return; }

        // 현재 카메라 위치 및 화면 크기 계산
        Vector3 camPosition = mainCamera.transform.position;
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // 픽셀 단위 -> World 단위로 변환
        float pixelToWorld = camHeight / Screen.height;
        float worldOffset = spawnOffset * pixelToWorld;

        // 랜덤한 화면 가장자리 선택 (위, 아래, 왼쪽, 오른쪽)
        int side = Random.Range(0, 4);
        Vector3 spawnPos = Vector3.zero;

        switch (side)
        {
            case 0: // 위쪽
                spawnPos = new Vector3(
                    Random.Range(camPosition.x - camWidth / 2, camPosition.x + camWidth / 2),
                    camPosition.y + camHeight / 2 + worldOffset,
                    0);
                break;
            case 1: // 아래쪽
                spawnPos = new Vector3(
                    Random.Range(camPosition.x - camWidth / 2, camPosition.x + camWidth / 2),
                    camPosition.y - camHeight / 2 - worldOffset,
                    0);
                break;
            case 2: // 왼쪽
                spawnPos = new Vector3(
                    camPosition.x - camWidth / 2 - worldOffset,
                    Random.Range(camPosition.y - camHeight / 2, camPosition.y + camHeight / 2),
                    0);
                break;
            case 3: // 오른쪽
                spawnPos = new Vector3(
                    camPosition.x + camWidth / 2 + worldOffset,
                    Random.Range(camPosition.y - camHeight / 2, camPosition.y + camHeight / 2),
                    0);
                break;
        }

        // 랜덤 오브젝트 선택 후 생성
        GameObject randomObject = monsterPrefabs[Random.Range(0, monsterPrefabs.Count)];
        Instantiate(randomObject, spawnPos, Quaternion.identity);
    }
}