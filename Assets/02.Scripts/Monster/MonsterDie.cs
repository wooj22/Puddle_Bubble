using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 1f); 
        }
    }
}
