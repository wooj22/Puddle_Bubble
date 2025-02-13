using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpwaner : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void FixedUpdate() //
    {
        
    }

    IEnumerator Fire()
    {
        Instantiate(bullet,Vector3.one,Quaternion.identity);
        yield return new WaitForSeconds(0.2f);  
        StartCoroutine(Fire());
    }
}
