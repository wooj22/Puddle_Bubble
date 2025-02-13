using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float explosionRadius = 3f;
    [SerializeField] CircleCollider2D bombAraa;

    public Vector3 moveVec = Vector3.zero;

    // conponets
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
            bombAraa.enabled = false;
            animator.SetBool("isBurst", true);
            DamageNearbyEnemies("SandMonster");
            Destroy(gameObject,0.5f);
        }
        else if (collision.gameObject.CompareTag("MudMonster"))
        {
            bombAraa.enabled = false;
            animator.SetBool("isBurst", true);
            DamageNearbyEnemies("MudMonster");
            Destroy(gameObject,0.5f);
        }
        else if (collision.gameObject.CompareTag("StoneMonster"))
        {
            bombAraa.enabled = false;
            animator.SetBool("isBurst", true);
            DamageNearbyEnemies("StoneMonster");
            Destroy(gameObject,0.5f);
        }
        if(animator == null) { Debug.Log("¾ø"); }
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

                StoneMonster stoneMonster = enemy.GetComponent<StoneMonster>();
                if (stoneMonster != null)
                {
                    stoneMonster.TakeDamage(damage);
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
