using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBullet : MonoBehaviour
{
    [SerializeField] float speed;            
    [SerializeField] float damage;           
    [SerializeField] float accuracy;         
    bool DirectrionChange = false;
    private void Start()
    {
        //Destroy(gameObject, 10f);
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
        transform.Translate(transform.right * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SandMonster"))
        {
            //SandMonster sandMonster = /enemy.GetComponent<SandMonster>();
            //sandMonster.TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("MudMonster"))
        {
            //MudMonster mudMonster = enemy.GetComponent<MudMonster>();
            //mudMonster.TakeDamage(damage);
        }
    }
}
