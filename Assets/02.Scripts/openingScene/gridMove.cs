using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMove : MonoBehaviour
{
    private float moveSpeed = 1.2f;
    private float waitTime = 5.0f;
    private bool canMove = false;
    [SerializeField] float extraDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove());
        StartCoroutine(extraDelayTime());
        StartCoroutine(MoveUpEvery100Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    private IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }

    private IEnumerator extraDelayTime()
    {
        yield return new WaitForSeconds(extraDelay);
    }

    private IEnumerator MoveUpEvery100Seconds()
    {
        yield return new WaitForSeconds(extraDelay);
        while (true)
        {
            yield return new WaitForSeconds(100.0f);
            transform.Translate(Vector3.up * 240.0f);
        }
    }
}
