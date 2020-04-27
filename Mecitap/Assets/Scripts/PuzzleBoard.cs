using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoard : MonoBehaviour
{
    public int width, height;

    //kartu-kartu
    private Card[,] boardCards;
    //public GameObject[,] BoardPieces { get { return boardPieces;  } }

    // Start is called before the first frame update
    void Start()
    {
        boardCards = new Card[width, height];   
    }

}
