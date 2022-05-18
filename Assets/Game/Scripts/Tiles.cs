using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    int xSize = 5, ySize = 9;
    public GameObject tile;

    [ContextMenu("Create Tiles")]
    private void CreateTiles()
    {
        float Dx = 1.42f, Dy = 1.4f;
        Vector3 startPosition = new Vector3(-0.4f, -3, 0);
        
        for(int y = 0; y < ySize; y++)
        {           

            for (int x = 0; x < xSize; x++)
            {
                Instantiate(tile, startPosition, Quaternion.identity);
                startPosition.x += Dx;
            }

            startPosition.x = -0.4f;
            startPosition.y += Dy;

            
        }    
    }
    

    void Start()
    {
        //CreateTiles();
    }








}
