using System.Collections.Generic;
using System.Collections;
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

    private Sprite _newTileFishSprite;
    private GameObject[,] _tilesArray;

    public bool IsShifting { get; set; }







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
            _newTileFishSprite = _tileFishSprite[Random.Range(0, _tileFishSprite.Count)];
            _tileFish.GetComponent<SpriteRenderer>().sprite = _newTileFishSprite;

            GameObject newTile = Instantiate(_tileFish, position, Quaternion.identity);
            _tilesArray[x, 0] = newTile;

            position.x += _distance.x;

        }

    }

    private IEnumerator FindNullTiles()
    {
        for(int x = 0; x < _size.x; x++)
        {
            for(int y = 0; y < _size.y; y++)
            {
                if (_tilesArray[x, y].GetComponent<SpriteRenderer>().sprite == null)
                {
                    yield return StartCoroutine(ShiftTilesDown(x, y));
                    break;
                }
            }
        }
    }

    private IEnumerator ShiftTilesDown(int x, int yStart, float shiftDelay = 0.3f)
    {
        IsShifting = true;
        List<SpriteRenderer> renders = new List<SpriteRenderer> ();
        int nullCount = 0;

        for(int y = yStart; y < _size.y; y++)
        {
            SpriteRenderer render = _tilesArray[x, y].GetComponent<SpriteRenderer>();
            if(render.sprite == null)
            {
                nullCount++;
            }
        }

        for(int i = 0; i < nullCount; i++)
        {
            yield return new WaitForSeconds(shiftDelay);

            for(int k = 0; k < renders.Count - 1; k++)
            {
                renders[k].sprite = renders[k + 1].sprite;
                renders[k + 1].sprite = null;
            }
        }

        IsShifting = false;
    }


    void Start()
    {
        
        CreateTiles();
        _tilesArray= new GameObject[_size.x, _size.y];
        CreateGameBoard();
        StartCoroutine(FindNullTiles());
    }


    private void Update()
    {
        
    }
}

    


   
    
