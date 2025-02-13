using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float explosionRadius = 10f;
    [SerializeField] CircleCollider2D bombAraa;

    public Vector3 moveVec = Vector3.zero;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Move();
    }

    // ÃÑ¾ËÀÌµ¿
    void Move()
    {
        transform.Translate(moveVec * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SandMonster"))
        {
            DamageNearbyEnemies("SandMonster");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("MudMonster"))
        {
            DamageNearbyEnemies("MudMonster");
            Destroy(gameObject);
        }
    }

    // ÆøÅº ¹üÀ§ Enemy get
    private void DamageNearbyEnemies(string monsterTag)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag(monsterTag))
            {
                SandMonster sandMonster = enemy.GetComponent<SandMonster>();
                if (sandMonster != null)
                {
                    sandMonster.TakeDamage(damage);
                }

                MudMonster mudMonster = enemy.GetComponent<MudMonster>();
                if (mudMonster != null)
                {
                    mudMonster.TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
