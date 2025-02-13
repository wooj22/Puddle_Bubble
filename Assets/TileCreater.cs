using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCreater : MonoBehaviour
{
    public Tilemap tilemap;               // 타일맵
    public Tile[] tiles;                  // 랜덤으로 배치할 타일들
    public Tile road;                     // 랜덤으로 배치할 타일들 (도로)
    public Tile grass;                    // 랜덤으로 배치할 타일들 (잔디)
    public Tile roadbleow;                // 랜덤으로 배치할 타일들 (도로,아래)
    public Tile grassbleow;               // 랜덤으로 배치할 타일들 (잔디,아래)
    public GameObject[] objectsToPlace;   // 랜덤으로 배치할 오브젝트들
    public Vector2Int gridSize;           // 타일맵 그리드 크기 (X, Y)

    public Transform gridParent;          // 부모 객체로 배치할 Grid (타일맵의 부모로 설정)

    public int minPlacementInterval = 1;  // 최소 배치 간격 (예: 1칸)
    public int maxPlacementInterval = 5;  // 최대 배치 간격 (예: 5칸)

    void Start()
    {
        PlaceRandomTiles();
    }

    // 타일을 랜덤하게 배치하는 함수
    void PlaceRandomTiles()
    {
        int size = gridSize.x / 2;

        // 1. 타일을 랜덤하게 배치
        for (int x = -size; x < size; x++)
        {
            for (int y = -size; y < size; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                Tile randomTile = tiles[Random.Range(0, tiles.Length)];
                tilemap.SetTile(tilePosition, randomTile);
            }
        }

        // 2. 도로 타일 배치 (y = 10 위치에)
        for (int y = -size; y < size; y++)
        {
            Vector3Int tilePosition = new Vector3Int(y, 10, 0);
            tilemap.SetTile(tilePosition, road);
        }

        // 3. 잔디 타일 배치 (y = 11 이상 위치에)
        for (int x = -size; x < size; x++)
        {
            for (int y = 11; y < size; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, grass);
            }
        }

        // 4. 도로 타일 배치 (y = -10 위치에)
        for (int y = -size; y < size; y++)
        {
            Vector3Int tilePosition = new Vector3Int(y, -10, 0);
            tilemap.SetTile(tilePosition, roadbleow);
        }

        // 5. 잔디 타일 배치 (y = -11 이하 위치에)
        for (int x = -size; x < size; x++)
        {
            for (int y = -11; y >= -size; y--)  // 아래쪽 타일맵 위치는 y가 -11 이하로 배치 (내림차순으로 수정)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, grassbleow);
            }
        }

        // 6. 잔디 타일 위치에만 랜덤 간격으로 오브젝트 배치
        PlaceRandomObjectsOnGrass();
    }

    // 잔디 타일 위에만 랜덤 오브젝트를 랜덤 간격으로 배치하는 함수
    void PlaceRandomObjectsOnGrass()
    {
        int size = gridSize.x / 2;

        // gridSize 크기 만큼 반복문을 돌며 랜덤 오브젝트 배치
        for (int x = -size + 1; x < size - 1; x++)   // 1칸 안쪽으로 배치 범위 조정
        {
            for (int y = -size + 1; y < size - 1; y++)  // 1칸 안쪽으로 배치 범위 조정
            {
                // y=10과 y=-10에서는 오브젝트를 배치하지 않음
                if (y == 11 || y == -10)
                {
                    continue; // 이 위치는 건너뛰기
                }

                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                // 해당 위치에 배치된 타일을 확인
                Tile currentTile = tilemap.GetTile<Tile>(tilePosition);

                // 현재 타일이 grass일 때만 오브젝트 배치
                if (currentTile == grass || currentTile == grassbleow)
                {
                    // 랜덤한 간격을 결정 (minPlacementInterval ~ maxPlacementInterval)
                    int randomIntervalX = Random.Range(minPlacementInterval, maxPlacementInterval + 1);
                    int randomIntervalY = Random.Range(minPlacementInterval, maxPlacementInterval + 1);

                    // 일정 간격으로만 오브젝트 배치
                    if (x % randomIntervalX == 0 && y % randomIntervalY == 0)
                    {
                        // 랜덤 오브젝트 선택
                        GameObject randomObject = objectsToPlace[Random.Range(0, objectsToPlace.Length)];

                        // 오브젝트를 그리드 위치에 배치
                        Vector3 position = tilemap.CellToWorld(tilePosition);  // 타일 위치를 월드 좌표로 변환

                        // 오브젝트 생성, 부모는 gridParent로 설정
                        GameObject placedObject = Instantiate(randomObject, position, Quaternion.identity);
                        placedObject.transform.SetParent(gridParent); // 타일맵의 부모로 설정
                    }
                }
            }
        }
    }

}
