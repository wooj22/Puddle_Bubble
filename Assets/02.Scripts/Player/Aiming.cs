using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aming : MonoBehaviour
{
    [SerializeField] private Sprite cursorSprite;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Material lineMaterial;

    private GameObject cursorObject;
    private LineRenderer lineRenderer;

    private void Start()
    {
        Cursor.visible = false;

        cursorObject = new GameObject("CursorSprite");
        SpriteRenderer sr = cursorObject.AddComponent<SpriteRenderer>();
        sr.sprite = cursorSprite;
        sr.sortingOrder = 10;

        // LineRenderer
        GameObject lineObj = new GameObject("AimLine");
        lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.sortingOrder = 5; // 커서보다 낮게

        // 점선 스타일 적용 (라인 머티리얼을 점선 스타일로 설정해야 함)
        lineRenderer.textureMode = LineTextureMode.Tile;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        cursorObject.transform.position = mousePosition;
        lineRenderer.SetPosition(0, playerTransform.position);
        lineRenderer.SetPosition(1, mousePosition);
    }
}
