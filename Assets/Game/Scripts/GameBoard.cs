using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameBoard : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private SpriteRenderer _tileFish;
	[SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();
	[SerializeField] private GameObject _tile;

	private Sprite _newTileFishSprite;
	private SpriteRenderer[,] _tilesArray;
	
	[SerializeField] private Vector2Int _size;
	[SerializeField] private Vector2 _distance;
	[SerializeField] private Vector2 _startPosition;

	[SerializeField] private float _speed;

	








	[ContextMenu("Create Tiles")]
	private void CreateTiles()
	{

		GameObject[,] _cellArray = new GameObject[_size.x, _size.y];
		Vector2 position = _startPosition;

		for (int y = 0; y < _size.y; y++)
		{

			for (int x = 0; x < _size.x; x++)
			{

				_cellArray[x, y] = Instantiate(_tile, position, Quaternion.identity);

				_cellArray[x, y].name = "Cell(" + x + "," + y + ")";
				
				position.x += _distance.x;
			}

			position.x =  _startPosition.x;
			position.y -= _distance.y;


		}
	}

	private SpriteRenderer[,] CreateGameBoard()
	{
		
		Vector2 position = _startPosition;
		Sprite previousLeft = null;
		
		for (int x = 0; x < _size.x; x++)
		{
			if (_tilesArray[x, 0] == null)
			{
				SpriteRenderer newTile = Instantiate(_tileFish, position, Quaternion.identity);
				_tilesArray[x, 0] = newTile;
				_tilesArray[x, 0].name = "Fish(" + x + "," + 0 + ")";
				newTile.transform.SetParent(this.transform);
				                

				List<Sprite> possibleFish = new List<Sprite>();
				possibleFish.AddRange(_tileFishSprite);
				possibleFish.Remove(previousLeft);

				_newTileFishSprite = possibleFish[Random.Range(0, possibleFish.Count)];
				_tileFish.GetComponent<SpriteRenderer>().sprite = _newTileFishSprite;
				previousLeft = _newTileFishSprite;

				position.x += _distance.x;

			}
							
			
		}
		return _tilesArray;
	}

  

   private SpriteRenderer[,] ShiftTilesDown()
   {
		
		for (int x = 0; x < _size.x; x++)
		{

			for (int y = 0; y < _size.y; y++)
			{
				Vector2 endPos = new Vector2(x, (y + 1) * - _distance.y);


				if (_tilesArray[x, y] != null && y <= _size.y - 2)
				{
					if (_tilesArray[x, y + 1] == null && y <= _size.y - 1)
					{
						_tilesArray[x, y].transform.Translate(0, -_speed * Time.deltaTime, 0, Space.Self);

						if (_tilesArray[x, y].transform.localPosition.y <= endPos.y)
						{
							_tilesArray[x, y + 1] = _tilesArray[x, y];
							_tilesArray[x, y + 1].name = "Fish(" + x + "," + (y + 1) + ")";
							_tilesArray[x, y] = null;

						}
					}
					
						
				}
						
					
				
			}
		}
		return _tilesArray;
		
   }
   
		
	
	




	void Start()
	{
		_tilesArray= new SpriteRenderer[_size.x, _size.y];
		CreateTiles();
		
	}

	void Update()
	{
		CreateGameBoard();
		ShiftTilesDown();
	}
}










	
