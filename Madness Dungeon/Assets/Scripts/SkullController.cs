using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;

    [SerializeField]
    private float speed = 0f;

    [SerializeField]
    private float maxRange = 0f;

    [SerializeField]
    private float minRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange)
        {
            if(Vector3.Distance(target.position, transform.position) >= minRange)
            {
                myAnim.SetBool("isMoving", true);
                FollowPlayer();
            }
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    public void FollowPlayer()
    {
        //myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, 
                            target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x,
                                            transform.position.y + difference.y);
        }
    }
}
