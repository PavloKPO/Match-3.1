using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _tileFish;
    [SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();

    [SerializeField] private Vector2Int _size;
    [SerializeField] private Vector2 _distance;
    [SerializeField] private Vector2 _startPosition;

    private void CreateGameBoard()
    {
        Vector2 _position = new Vector2(_startPosition.x, _startPosition.y);
        
        for (int x = 0; x < _size.x; x++)
        {
            Instantiate(_tileFish, _position, Quaternion.identity);
            _position.x += _distance.x ;
        }

    }

    void Start()
    {
        CreateGameBoard();
    }

}
