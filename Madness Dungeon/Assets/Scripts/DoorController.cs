using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    GameObject[] enemies;
    GameObject[] items;
    public GameObject PopUpFinished;
    public GameObject PopUpYetKilled;
    public GameObject PopUpYetCollect;
    public GameObject PopUpYetAll;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("sentuh door");
            if (enemies.Length == 0 && items.Length == 0)
            {
                PopUpFinished.SetActive(true);       
            }
            else if (enemies.Length != 0 && items.Length == 0)
            {
                Debug.Log("Belum bunuh semua bro");
                PopUpYetKilled.SetActive(true);
            }
            else if (enemies.Length == 0 && items.Length != 0)
            {
                Debug.Log("Belum collect semua bro");
                PopUpYetCollect.SetActive(true);
            }
            else
            {
                Debug.Log("Belum semua bro");
                PopUpYetAll.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PopUpYetKilled.SetActive(false);
            PopUpYetCollect.SetActive(false);
            PopUpYetAll.SetActive(false);
        }
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        items = GameObject.FindGameObjectsWithTag("Collectible");
    }
}
