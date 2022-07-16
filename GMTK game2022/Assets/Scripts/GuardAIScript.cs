using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAIScript : MonoBehaviour
{
    private int playerPieceMask;
    private bool walkPointSet;
    private NavMeshAgent agent;
    private Vector3 currentWalkPoint;

    public Vector3 pointA;
    public Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPieceMask = 1 << 7;
        walkPointSet = false;
        transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!walkPointSet) {
            setWalkPoint();
        }
        if (walkPointSet) {
            Vector3 distanceToWalkPoint = transform.position - currentWalkPoint;
            if (distanceToWalkPoint.magnitude < 1f) {
            
            }
            //check if im within range of the new point
            //if so unset walkpointset

        }
    }

    void setWalkPoint() {
        if (currentWalkPoint == pointA) {
            currentWalkPoint = pointB;
        }
        if (currentWalkPoint == pointB) {
            currentWalkPoint = pointA;
        }
        walkPointSet = true;
    }
}
