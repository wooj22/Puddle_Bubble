using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ★ 몬스터 스폰 ★


public class MonsterSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mudMonsterPrefab;
    public GameObject sandMonsterPrefab;
    public GameObject stoneMonsterPrefab;

    public MonsterType monsterType;

    float spawnIntervalMin = 0f;
    float spawnIntervalMax = 5f;
    float spawnOffset = 100f;

    private float nextSpawnTime;

    public Transform spawnParent; // 생성된 몬스터들의 부모(Parent)


    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMonster();
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    void SpawnMonster()
    {
        if (mainCamera == null) { return; }

        Vector3 spawnPosition = GetRandomOffScreenPosition();

        // 몬스터 타입 랜덤 선택
        MonsterType selectedType = (MonsterType)Random.Range(0, 3);

        GameObject monsterPrefab = null;
        switch (selectedType)
        {
            case MonsterType.Sand:
                monsterPrefab = sandMonsterPrefab;
                break;
            case MonsterType.Mud:
                monsterPrefab = mudMonsterPrefab;
                break;
            case MonsterType.Stone:
                monsterPrefab = stoneMonsterPrefab;
                break;
        }

        if (monsterPrefab == null) { return; }

        GameObject monsterObject = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity, spawnParent);
        Monster monster = monsterObject.GetComponent<Monster>();

        if (monster != null)
        {
            // 등급 랜덤 설정
            MonsterGrade randomGrade = (MonsterGrade)Random.Range(0, 4);
            monster.Grade = randomGrade;

            // 등급별 가중치 적용
            monster.ApplyGradeModifiers();
           // monster.UpdateSprite(randomGrade); // 몬스터 색상 코드 조정 
        }
        else { return; }
    }

    private Vector3 GetRandomOffScreenPosition()
    {
        Vector3 camPosition = mainCamera.transform.position;
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float pixelToWorld = camHeight / Screen.height;
        float worldOffset = spawnOffset * pixelToWorld;

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

        return spawnPos;
    }
}
