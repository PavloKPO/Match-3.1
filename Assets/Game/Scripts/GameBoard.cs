using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject tileFish;
    [SerializeField] private List<Sprite> tileFishSprite = new List<Sprite>();
    [SerializeField] private int xSize = 5, ySize = 9;
    [SerializeField] private float xDistance = 1.4f, yDistance = 1.4f;

    Vector3 startPosition = new Vector3(-0.38f, 8.2f, 0);
    private void CreateGameBoard()
    {       
               
        for(int x = 0; x < xSize; x++)
        {
            Instantiate(tileFish, startPosition, Quaternion.identity);
            startPosition.x += xDistance;
        }

    }

    void Start()
    {
        CreateGameBoard();
    }

}
