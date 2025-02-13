using System.Collections;
using UnityEngine;

public enum PubbleState
{
    gatling,
    bomb,
    water,
}

public class PubbleContorl : MonoBehaviour
{
    public PubbleState state;
    public int maxBubble;
    public int curBubble;
}
