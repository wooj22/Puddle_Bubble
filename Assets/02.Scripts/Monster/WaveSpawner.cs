using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;  // 카메라를 중심으로 회전하는 3개 오브젝트
    public List<GameObject> monsterList1; // 첫 번째 몬스터 리스트
    public List<GameObject> monsterList2; // 두 번째 몬스터 리스트
    public List<GameObject> monsterList3; // 세 번째 몬스터 리스트

    float waveIntervalMin = 0f;
    float waveIntervalMax = 5f;

    private List<List<GameObject>> allMonsterLists; // 모든 리스트를 저장할 리스트

    void Start()
    {
        // 모든 몬스터 리스트를 하나의 리스트에 저장
        allMonsterLists = new List<List<GameObject>> { monsterList1, monsterList2, monsterList3 };

        // 몬스터 스폰 루틴 시작
        StartCoroutine(SpawnMonsterRoutine());
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(waveIntervalMin, waveIntervalMax);
            yield return new WaitForSeconds(waitTime);

            StartCoroutine(SpawnMonsters());
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
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f); // 1초 대기 후 다음 몬스터 스폰
        }
    }
}