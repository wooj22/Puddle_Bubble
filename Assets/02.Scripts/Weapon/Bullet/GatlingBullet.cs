using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBullet : MonoBehaviour
{
    [SerializeField] float speed;            
    [SerializeField] float damage;           
    [SerializeField] float accuracy;         
    bool DirectrionChange = false;

    public Vector3 moveVec = Vector3.zero;

    // conponets
    private Animator animator;
    private CircleCollider2D collider2D;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponentInChildren<CircleCollider2D>();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        if (DirectrionChange == false)
        {
            DirectrionChange = true;
            transform.right += new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 0);
        }
        Move();
    }

    // √—æÀ¿Ãµø
    void Move()
    {
        transform.Translate(moveVec * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SandMonster"))
        {
            collision.gameObject.GetComponent<SandMonster>().TakeDamage(damage);
            collider2D.enabled = false;
            animator.SetBool("isBurst", true);
            Destroy(gameObject,0.5f);
        }

        if (collision.gameObject.CompareTag("MudMonster"))
        {
            collision.gameObject.GetComponent<MudMonster>().TakeDamage(damage);
            collider2D.enabled = false;
            animator.SetBool("isBurst", true);
            Destroy(gameObject,0.5f);
        }

        if (collision.gameObject.CompareTag("StoneMonster"))
        {
            collision.gameObject.GetComponent<StoneMonster>().TakeDamage(damage);
            collider2D.enabled = false;
            animator.SetBool("isBurst", true);
            Destroy(gameObject,0.5f);
        }
    }
}
