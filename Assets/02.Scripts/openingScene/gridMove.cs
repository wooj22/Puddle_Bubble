using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMove : MonoBehaviour
{
    private float moveSpeed = 1.2f;
    private float waitTime = 5.0f;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= -120.0f)
            {
                transform.Translate(Vector3.up * 240.0f);
            }
        }
    }

    private IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }
}
