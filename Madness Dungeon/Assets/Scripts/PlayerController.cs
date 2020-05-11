using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;
    private Animator anim;
    private bool moving;
    private Vector2 lastMove;
    public LayerMask WhatStopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0.2f * Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, WhatStopMovement))
            {
                movePoint.position += new Vector3(0.2f * Input.GetAxisRaw("Horizontal"), 0f, 0f);
                moving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 0.2f * Input.GetAxisRaw("Vertical"), 0f), .2f, WhatStopMovement))
            {
                movePoint.position += new Vector3(0f, 0.2f * Input.GetAxisRaw("Vertical"), 0f);
                moving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", moving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
