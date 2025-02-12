using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ★ 몬스터 스폰 ★


public class MonsterSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mudMonsterPrefab;
    public GameObject sandMonsterPrefab;

    float spawnIntervalMin = 0f;
    float spawnIntervalMax = 5f;
    float spawnOffset = 100f;

    private float nextSpawnTime;

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
        if (mainCamera == null) { Debug.LogError("Main Camera is not assigned in MonsterSpawner."); return; }

        Vector3 spawnPosition = GetRandomOffScreenPosition();

        // 몬스터 타입 랜덤 선택
        MonsterType selectedType = Random.value > 0.5f ? MonsterType.Sand : MonsterType.Mud;
        GameObject monsterPrefab = selectedType == MonsterType.Sand ? sandMonsterPrefab : mudMonsterPrefab;

        GameObject monsterObject = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        Monster monster = monsterObject.GetComponent<Monster>();

        if (monster != null)
        {
            // 등급 랜덤 설정
            MonsterGrade randomGrade = (MonsterGrade)Random.Range(0, 4);
            monster.Grade = randomGrade;
            monster.UpdateSprite(randomGrade);
        }
        else { Debug.LogError("Spawned monster prefab does not have a Monster script attached."); }
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
