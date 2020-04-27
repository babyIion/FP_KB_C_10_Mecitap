using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool walkable;
    public int gridX;
    public int gridY;
    //public int price;

    public int gCost;
    public int hCost;
    public Card parent;

    //create the grid card
    public Card(bool _walkable, int _gridX, int _gridY)
    {
        walkable = _walkable;
        //price = _walkable ? 1f : 0f;
        gridX = _gridX;
        gridY = _gridY;
    }

    //update the grid card
    public void Update(bool _walkable, int _gridX, int _gridY)
    {
        walkable = _walkable;
        //price = _walkable ? 1f : 0f;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
