using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    GameObject[] enemies;
    GameObject[] items;
    public Text enemyCountText;
    public Text collectCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        items = GameObject.FindGameObjectsWithTag("Collectible");

        enemyCountText.text = "Enemies to kill:" + enemies.Length.ToString();
        collectCountText.text = "Collectible:" + items.Length.ToString();
    }
}
