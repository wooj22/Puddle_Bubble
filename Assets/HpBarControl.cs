
using UnityEngine;

public class HpBarControl : MonoBehaviour
{
    Monster monster;
    float maxHp;
    RectTransform rect;

    void Start()
    {
        monster = this.transform.parent.parent.GetComponent<Monster>();
        rect = GetComponent<RectTransform>();
        maxHp = monster.Health;
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(monster.Health/maxHp,0.1f);
    }
}
