using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameBoard : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private GameObject _tileFish;
	[SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();
	[SerializeField] private GameObject _tile;

	private Sprite _newTileFishSprite;
	private GameObject[,] _tilesArray;

	[SerializeField] private Vector2Int _size;
	[SerializeField] private Vector2 _distance;
	[SerializeField] private Vector2 _startPosition;

	


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

	private void CreateGameBoard()
	{
		
		Vector2 position = _startPosition;
		_tilesArray= new GameObject[_size.x, _size.y];

		for (int x = 0; x < _size.x; x++)
		{           
			GameObject newTile = Instantiate(_tileFish, position, Quaternion.identity);
			_tilesArray[x, 0] = newTile;
			_tilesArray[x, 0].name = "Fish(" + x + "," + 0 + ")";
			newTile.transform.SetParent(this.transform);


			_newTileFishSprite = _tileFishSprite[Random.Range(0, _tileFishSprite.Count)];
			_tileFish.GetComponent<SpriteRenderer>().sprite = _newTileFishSprite;

		   position.x += _distance.x;                     
						
			
		}
		
	}

  

   private void ShiftTilesDown()
   {
		Vector2 tempPos;
		for (int x = 0; x < _size.x; x++)
		{
			for (int y = 0; y < _size.y; y++)
			{
				if (_tilesArray[x, y] != null)
				{
					if (_tilesArray[x, y +1] == null)
					{
						
						SpriteRenderer render = _tilesArray[x, y].GetComponent<SpriteRenderer>();
						
						tempPos = _tilesArray[x, y].transform.position;
						transform.position = new Vector2(tempPos.x, tempPos.y - _distance.y);
						render.sprite =  _tilesArray[x, y +1];
						_tilesArray[x, y] = null;

						
						
					}
				}
			}
		}
		
	   
   }












	private void Start()
	{
		CreateTiles();
		CreateGameBoard();
		//ShiftTilesDown();
	   
	}

	void Update()
	{
		
	}
}










	
