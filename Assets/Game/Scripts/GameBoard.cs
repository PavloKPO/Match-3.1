using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _tileFish;
    [SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();
    [SerializeField] private GameObject _tile;
             
    [SerializeField] private Vector2Int _size;
    [SerializeField] private Vector2 _distance;
    [SerializeField] private Vector2 _startPosition;



    [ContextMenu("Create Tiles")]
    private void CreateTiles()
    {
        Vector2 position = _startPosition;

        for (int y = 0; y < _size.y; y++)
        {

            for (int x = 0; x < _size.x; x++)
            {
                Instantiate(_tile, position, Quaternion.identity);
                position.x += _distance.x;
            }

            position.x =  _startPosition.x;
            position.y -= _distance.y;


        }
    }
    private void CreateGameBoard()
    {
        Vector2 position = _startPosition;
        
        for (int x = 0; x < _size.x; x++)
        {
            Instantiate(_tileFish, position, Quaternion.identity);
            position.x += _distance.x ;
        }

    }


    void Start()
    {
        CreateTiles();
        CreateGameBoard();
    }

}
