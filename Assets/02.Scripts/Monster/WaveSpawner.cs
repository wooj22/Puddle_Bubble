using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> monsterList1;
    public List<GameObject> monsterList2;
    public List<GameObject> monsterList3;

    public float waveIntervalMin = 10f; // 웨이브 최소 대기 시간
    public float waveIntervalMax = 15f; // 웨이브 최대 대기 시간
    public float monsterSpawnInterval = 0.5f; // 몬스터 개별 스폰 간격

    private List<List<GameObject>> allMonsterLists; // 모든 리스트 저장할 리스트
    public Transform waveParent;                    // 생성된 몬스터들의 부모(Parent)

    void Start()
    {
        // 모든 몬스터 리스트를 하나의 리스트에 저장
        allMonsterLists = new List<List<GameObject>> { monsterList1, monsterList2, monsterList3 };

        StartCoroutine(SpawnMonsterRoutine());
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(waveIntervalMin, waveIntervalMax);
            yield return new WaitForSeconds(waitTime);

            // `yield return`을 사용하여 웨이브가 끝날 때까지 대기
            yield return StartCoroutine(SpawnMonsters());
        }
    }

    IEnumerator SpawnMonsters()
    {
        if (spawnPoints.Count == 0 || allMonsterLists.Count == 0) yield break;

        // 회전하는 오브젝트 중 랜덤한 위치 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;

        // 몬스터 리스트 중 랜덤 선택
        List<GameObject> selectedMonsterList = allMonsterLists[Random.Range(0, allMonsterLists.Count)];

        // 리스트에 있는 모든 몬스터 스폰
        if (selectedMonsterList.Count == 0) yield break;

        foreach (GameObject monsterPrefab in selectedMonsterList)
        {
            GameObject monsterObject = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity, waveParent);
            Monster monster = monsterObject.GetComponent<Monster>();

            if (monster != null)
            {
                // 등급 랜덤 설정
                MonsterGrade randomGrade = (MonsterGrade)Random.Range(0, 4);
                monster.Grade = randomGrade;

                // 등급별 가중치 적용
                monster.ApplyGradeModifiers();
                // monster.UpdateSprite(randomGrade);
            }

            yield return new WaitForSeconds(monsterSpawnInterval); // 0.5초 간격으로 스폰
        }
    }
}

