using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] int life;
    private float remainDamage;

    public Vector3 moveVec = Vector3.zero;

    private void Start()
    {
        remainDamage = damage;
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Move();
    }

    // 총알이동
    void Move()
    {
        transform.Translate(moveVec * speed * Time.deltaTime, Space.Self);
    }

    // 공격
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SandMonster"))
        {
            SandMonster sandMonster = collision.gameObject.GetComponent<SandMonster>();
            int mosterHP = sandMonster.GetHealth();
            if(remainDamage >= mosterHP)
            {
                sandMonster.TakeDamage(mosterHP);
                remainDamage -= mosterHP;
            }
            else
            {
                sandMonster.TakeDamage(remainDamage);
                remainDamage = 0;
            }
            life--;
        }
        
        if (collision.gameObject.CompareTag("MudMonster"))
        {
            MudMonster mudMonster = collision.gameObject.GetComponent<MudMonster>();
            int mosterHP = mudMonster.GetHealth();
            if (remainDamage >= mosterHP)
            {
                mudMonster.TakeDamage(mosterHP);
                remainDamage -= mosterHP;
            }
            else
            {
                mudMonster.TakeDamage(remainDamage);
                remainDamage = 0;
            }
            life--;
        }

        if (life <= 0 || remainDamage == 0)
        {
            Destroy(gameObject);
        }
    }
}
