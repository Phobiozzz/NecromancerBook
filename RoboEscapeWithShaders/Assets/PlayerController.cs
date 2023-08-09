using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 playerCurrentPosition;

    private Ray ray;
    private RaycastHit hit;
    private NavMeshAgent agent;
    private Vector3 pointToMovePosition;
    bool moving = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pointToMovePosition = transform.position;
    }

    private void Update()
    {
        playerCurrentPosition = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Ground":
                        pointToMovePosition = hit.point;
                        moving = true;
                        break;
                    case "Wall":
                        pointToMovePosition = hit.point;
                        moving = true;
                        break;
                }
            }
        }


        if (moving)
        {
            if (Vector3.Distance(playerCurrentPosition, pointToMovePosition) > 0.5f)
            {
                agent.SetDestination(pointToMovePosition);
            }
            else
            {
                moving = false;
            }
        }
    }

   
}
