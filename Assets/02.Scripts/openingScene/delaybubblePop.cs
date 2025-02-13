using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delaybubblePop : MonoBehaviour
{
    private Animator animator;
    public float delayMin = 2f;
    public float delayMax = 4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ActivateAnimatorWithDelay());
    }

    private IEnumerator ActivateAnimatorWithDelay()
    {
        float delay = Random.Range(delayMin, delayMax);
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
