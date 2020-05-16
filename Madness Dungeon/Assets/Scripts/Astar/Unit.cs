using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    private Animator myAnim;
    public Transform target;
    public float speed = 10;

    [SerializeField]
    private float maxRange = 0f;

    Vector2[] path;
    int targetIndex;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        StartCoroutine(RefreshPath());
    }

    IEnumerator RefreshPath()
    {
        Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially

        while (true)
        {
            if (targetPositionOld != (Vector2)target.position)
            {
                targetPositionOld = (Vector2)target.position;

                if(Vector3.Distance(target.position, transform.position) <= maxRange)
                {
                    path = Pathfinding.RequestPath(transform.position, target.position);
                    StopCoroutine("FollowPath");
                    StartCoroutine("FollowPath");
                }
                else
                {
                    myAnim.SetBool("isMoving", false);
                }
            }

            yield return new WaitForSeconds(.25f);
        }
    }

    IEnumerator FollowPath()
    {
        myAnim.SetBool("isMoving", true);
        if (path.Length > 0)
        {
            targetIndex = 0;
            Vector2 currentWaypoint = path[0];

            while (true)
            {
                if ((Vector2)transform.position == currentWaypoint)
                {
                    targetIndex++;
                    if (targetIndex >= path.Length)
                    {
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }
                myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
                myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));

                transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                yield return null;

            }
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                //Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}