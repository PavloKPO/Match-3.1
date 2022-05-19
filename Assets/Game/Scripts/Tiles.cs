using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] private int xSize = 5, ySize = 9;
    [SerializeField] private GameObject tile;
    [SerializeField] private float xDistance = 1.42f, yDistance = 1.4f;

    Vector3 startPosition = new Vector3(-0.4f, -3, 0);

    [ContextMenu("Create Tiles")]
    private void CreateTiles()
    {        
        
        for(int y = 0; y < ySize; y++)
        {           

            for (int x = 0; x < xSize; x++)
            {
                Instantiate(tile, startPosition, Quaternion.identity);
                startPosition.x += xDistance;
            }

            startPosition.x = -0.4f;
            startPosition.y += yDistance;

            
        }    
    }
    

    void Start()
    {
        //CreateTiles();
    }








}
