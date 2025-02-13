using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // 캐릭터 이동 속도
    private Rigidbody2D rb;       // Rigidbody2D 컴포넌트를 저장할 변수

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 수평 (좌우) 및 수직 (상하) 입력 처리
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 캐릭터의 이동 방향 설정 (상하좌우 모두 가능)
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Rigidbody2D를 사용하여 캐릭터 이동
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
