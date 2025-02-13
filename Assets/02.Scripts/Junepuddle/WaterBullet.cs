using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] int life;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Move();
    }

    // 총알이동
    void Move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int monsterHp=0;
        if (collision.gameObject.CompareTag("SandMonster"))
        {
            //SandMonster sandMonster = /enemy.GetComponent<SandMonster>();
            //sandMonster.TakeDamage(damage);
            //monsterHp = mudMonster.GetHp();
        }
        else if (collision.gameObject.CompareTag("MudMonster"))
        {
            //MudMonster mudMonster = enemy.GetComponent<MudMonster>();
            //mudMonster.TakeDamage(damage);
            //몬스터의 체력을 가져온다
            //monsterHp = mudMonster.GetHp();

        }
        if (monsterHp == 0)
            return;
        damage -= monsterHp;
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
