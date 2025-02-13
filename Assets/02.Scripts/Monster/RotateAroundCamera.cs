using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAroundCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationSpeed = 30f;
    private Vector3 offset;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // 초기 위치와 카메라 위치 차이 저장
        offset = transform.position - cameraTransform.position;
    }

    void Update()
    {
        if (cameraTransform == null) return;

        // 움직이는 카메라와 일정한 거리 유지하면서 회전
        transform.position = cameraTransform.position + offset;
        transform.RotateAround(cameraTransform.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        // 현재 위치 기준으로 새로운 offset 계산
        offset = transform.position - cameraTransform.position;
    }
}
