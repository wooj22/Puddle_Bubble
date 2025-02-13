using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] CircleCollider2D bombAraa;
    [SerializeField] CircleCollider2D damageArea;

    private void Start()
    {
        damageArea = GetComponent<CircleCollider2D>();
        bombAraa.enabled = true;
        damageArea.enabled = false;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(transform.right * speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if 적과 충돌하면
        bombAraa.enabled = false;
        damageArea.enabled = true;
        Destroy(gameObject);
    }
}
