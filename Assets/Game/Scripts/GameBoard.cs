using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _tileFish;
    [SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();

    [SerializeField] private int _xSize;
    [SerializeField] private int _ySize;
    [SerializeField] private float _xDistance;
    [SerializeField] private float _yDistance;
    [SerializeField] private Vector2 _startPosition;

    private void CreateGameBoard()
    {
        Vector2 _position = new Vector2(_startPosition.x, _startPosition.y);
        
        for (int x = 0; x < _xSize; x++)
        {
            Instantiate(_tileFish, _position, Quaternion.identity);
            _position.x += _xDistance ;
        }

    }

    void Start()
    {
        CreateGameBoard();
    }

}
