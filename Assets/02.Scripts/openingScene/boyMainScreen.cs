using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position += new Vector3(0, 1.2f * Time.deltaTime, 0);
        }
//        else
//        {
//            gameObject.GetComponent<Animator>().enabled = false;
//        }
    }
}
