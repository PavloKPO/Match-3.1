using System.Collections.Generic;
using UnityEngine;



public class GameBoard : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _tileFish;
	[SerializeField] private List<Sprite> _tileFishSprite = new List<Sprite>();
	[SerializeField] private GameObject _tile;

	private SpriteRenderer[,] _tilesArray;
	
	[SerializeField] private Vector2Int _size;
	[SerializeField] private Vector2 _distance;
	[SerializeField] private Vector2 _startPosition;

	[SerializeField] private float _speed;

	private void Start()
	{
		_tilesArray= new SpriteRenderer[_size.x, _size.y];
		CreateTiles();
	}

	private void Update()
	{
		FillTopTilesRaw();
		ShiftTilesDown();
	}



	[ContextMenu("Create Tiles")]
	private void CreateTiles()
	{
		GameObject[,] _cellArray = new GameObject[_size.x, _size.y];
		Vector2 distanceX = new Vector2(_distance.x, 0f);
		Vector2 tempPos = _startPosition;

		for (int y = 0; y < _size.y; y++)
		{
			for (int x = 0; x < _size.x; x++)
			{
				_cellArray[x, y] = Instantiate(_tile, (tempPos + distanceX * x), Quaternion.identity);
				_cellArray[x, y].name = "Cell(" + x + "," + y + ")";			
			}
			tempPos.x = _startPosition.x;
			tempPos.y -= _distance.y; 

		}
	}

	private void FillTopTilesRaw()
	{		
		Vector2 distanceX = new Vector2(_distance.x, 0f);		

		for (int x = 0; x < _size.x; x++)
		{
			if (_tilesArray[x, 0] == null)
			{				
				SpriteRenderer newTile = Instantiate(_tileFish, (_startPosition + distanceX * x), Quaternion.identity, transform);
				_tilesArray[x, 0] = newTile;
				_tilesArray[x, 0].name = "Fish(" + x + "," + 0 + ")";

				List<Sprite> tempFishSprite = new List<Sprite>();
				tempFishSprite.AddRange(_tileFishSprite);
				newTile.sprite = tempFishSprite[Random.Range(0, tempFishSprite.Count)];
			}
				
		}
		
	}

	private void ShiftTilesDown()
	{
		for (int x = 0; x < _size.x; x++)
		{
			for (int y = 0; y < _size.y - 1; y++)
			{
				ref SpriteRenderer tile = ref _tilesArray[x, y];
				ref SpriteRenderer lowTile = ref _tilesArray[x, y + 1];

				if (tile == null || lowTile != null)
					continue;

				Vector2 endPos = new Vector2(x * _distance.y, (y + 1) * - _distance.x);
				tile.transform.Translate(0, -_speed * Time.deltaTime, 0, Space.Self);

				if (tile.transform.localPosition.y > endPos.y)
					continue;

				tile.transform.localPosition = endPos;
				tile.name = GetTileName(x, y + 1);
				lowTile = tile;
				tile = null;

			}
		}
	} 	
		
	private static string GetTileName(int x, int y)
	{
		return "Fish(" + x + "," + y + ")";
	}
	
}










	
