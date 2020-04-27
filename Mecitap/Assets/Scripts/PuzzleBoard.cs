using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoard : MonoBehaviour
{
    public Card[,] cards;
    public int gridSizeX, gridSizeY;

    public PuzzleBoard(int width, int height, bool[,] walkable_tiles)
    {
        gridSizeX = width;
        gridSizeY = height;
        cards = new Card[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cards[x, y] = new Card(walkable_tiles[x, y] ? 1.0f : 0.0f, x, y);
            }
        }
    }

    public List<Card> GetNeighbours(Card card)
    {
        List<Card> neighbours = new List<Card>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int checkX = card.gridX + x;
                int checkY = card.gridY + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(cards[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

}
