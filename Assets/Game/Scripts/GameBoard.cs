using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject tileFish;
    public List<Sprite> tileFishSprite = new List<Sprite>();

    int xSize = 5, ySize = 9;

    private void CreateGameBoard()
    {
        float Dx = 1.42f, Dy = 1.4f;
        Vector3 startPosition = new Vector3(-0.38f, 8.2f, 0);
               
        for(int x = 0; x < xSize; x++)
        {
            Instantiate(tileFish, startPosition, Quaternion.identity);
            startPosition.x += Dx;
        }

    }

    void Start()
    {
        CreateGameBoard();
    }

}
