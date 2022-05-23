using UnityEngine;



public class Tiles : MonoBehaviour
{
    [SerializeField] private int _xSize;
    [SerializeField] private int _ySize;           
    [SerializeField] private float _yDistance;
    [SerializeField] private float _xDistance;

    [SerializeField] private Vector2 _startPosition;
    
    [SerializeField] private GameObject _tile;    

    [ContextMenu("Create Tiles")]
    private void CreateTiles()
    {
        
        Vector2 _position = new Vector2(_startPosition.x, _startPosition.y);
        
        for (int y = 0; y < _ySize; y++)
        {           

            for (int x = 0; x < _xSize; x++)
            {
                Instantiate(_tile, _position, Quaternion.identity);
                _position.x += _xDistance;
            }

            _position.x =  _startPosition.x;
            _position.y += _yDistance;

            
        }    
    }
    

    void Start()
    {
        
        //CreateTiles();
    }








}
