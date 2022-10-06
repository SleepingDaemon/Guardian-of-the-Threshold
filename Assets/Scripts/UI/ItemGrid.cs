using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    [SerializeField] private float _tileSizeWidth = 24f;
    [SerializeField] private float _tileSizeHeight = 24f;
    private RectTransform _rectTransform;
    Vector2 positionOnGrid = new Vector2();
    Vector2Int _tileGridPosition = new Vector2Int();

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnGrid.x = mousePosition.x - _rectTransform.position.x;
        positionOnGrid.y = _rectTransform.position.y - mousePosition.y;

        _tileGridPosition.x = (int)(positionOnGrid.x / _tileSizeWidth);
        _tileGridPosition.y = (int)(positionOnGrid.y / _tileSizeHeight);

        return _tileGridPosition;
    }
}
