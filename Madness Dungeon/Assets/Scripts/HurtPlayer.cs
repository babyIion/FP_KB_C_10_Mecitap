using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    private int damageToGive = 5;
    private HealthManager healthMan;
    private float waitToHurt = 2f;
    private bool isTouching;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        } 
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
