using UnityEngine;



public class Tiles : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;        
    [SerializeField] private Vector2 _distance;    
    [SerializeField] private Vector2 _startPosition;
    
    [SerializeField] private GameObject _tile;    

    [ContextMenu("Create Tiles")]
    private void CreateTiles()
    {   
                
        Vector2 _position = new Vector2(_startPosition.x, _startPosition.y);
        
        for (int y = 0; y < _size.y; y++)
        {           

            for (int x = 0; x < _size.x; x++)
            {
                Instantiate(_tile, _position, Quaternion.identity);
                _position.x += _distance.x;
            }

            _position.x =  _startPosition.x;
            _position.y += _distance.y;

            
        }    
    }
    

    void Start()
    {
        
        //CreateTiles();
    }








}
