using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootSpeed;
    private float currentSpeed;

    private float horizontal;
    private float vertical;

    //component
    private Rigidbody rb;
    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Rotation();
    }

    // 이동
    private void Move()
    {
        // input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // speed set
        if (Input.GetMouseButton(0))
        {
            Player.Instance.currentPlayerState = Player.PlayerState.Shoot;
            currentSpeed = shootSpeed;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Player.Instance.currentPlayerState = Player.PlayerState.Move;
            currentSpeed = moveSpeed;
        }
        else
        {
            Player.Instance.currentPlayerState = Player.PlayerState.Idle;
        }

        // move
        rb.velocity = new Vector2(horizontal * currentSpeed, vertical * currentSpeed).normalized;
    }

    // 플레이어 회전 애니메이션(?)
    private void Rotation()
    {

    }
}
