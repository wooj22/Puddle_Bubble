using System.Collections;
using UnityEngine;

public enum PubbleState
{
    gatling,
    bomb,
    bigball,
    size
}

public class PubbleContorl : MonoBehaviour
{
    public PubbleState state;
    public int maxBubble;
    public int curBubble;
    public int Step;
    public int StepGap;
    public int addSpeed;
    public int Timer;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        state = (PubbleState)Random.Range(0, (int)PubbleState.size);      
        StepGap = maxBubble / 5;
        Step = curBubble / StepGap;
        spriteRenderer = GetComponent <SpriteRenderer>();
        StartCoroutine(AddBubble());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddBubble()
    {
        if (curBubble < maxBubble)
        {
            curBubble++;
        }
        int curstep = curBubble / StepGap;
        if (curstep != Step)
        {
            Step = curstep;
            //spriteRenderer.sprite = Resources.Load<Sprite>("bubble") as Sprite;
            //현재 step과 상태에 맞는 웅덩이 스프라이트 불러오기 
        }

        yield return new WaitForSeconds(Timer);
        StartCoroutine(AddBubble());
    }
}
