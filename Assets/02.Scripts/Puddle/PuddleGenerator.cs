using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> puddleList;   // ¿õµ¢ÀÌ Á¾·ùº° ÇÁ¸®ÆÕ
    [SerializeField] int puddleMaxCount;            // »ý¼ºÇÒ ¿õµ¢ÀÌ °¹¼ö
    private List<Vector2> posList = new List<Vector2>();

    private void Start()
    {
        PosSetting();
        CreatPuddle();
    }

    // Æ÷Áö¼Ç set
    void PosSetting()
    {
        for (int i = 0; i < puddleMaxCount; i++)
        {
            float x = Random.Range(-45f, 45f);
            float y = Random.Range(-45f, 45f);
            posList.Add(new Vector2(x, y));
        }
    }

    // ÆÛµé »ý¼º
    void CreatPuddle()
    {
        for (int i = 0; i < puddleMaxCount; i++)
        {
            GameObject puddlePrefab = puddleList[i % puddleList.Count];
            GameObject puddle = Instantiate(puddlePrefab, posList[i], Quaternion.identity);
            puddle.transform.SetParent(this.transform);
        }
    }
}
