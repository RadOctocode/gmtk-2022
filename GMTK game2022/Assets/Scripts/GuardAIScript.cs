using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAIScript : MonoBehaviour
{
    private int playerPieceMask;
    private bool walkPointSet;
    private bool chasing;
    private GameObject chasePiece;
    private NavMeshAgent agent;
    private Vector3 currentWalkPoint;
    private Queue<Vector3> enemyRoute;
    private bool playerInSightRange;
    
    public float sightRange;
    // Start is called before the first frame update
    void Start()
    {
        enemyRoute = new Queue<Vector3>();
        agent = GetComponent<NavMeshAgent>();
        playerPieceMask = 1 << 7;
        walkPointSet = false;
        chasing = false;
        playerInSightRange = false;

        enemyRoute.Enqueue(new Vector3(-2.0f, 0.0f, -6.0f));
        enemyRoute.Enqueue(new Vector3(-2.0f, 0.0f, 6.0f));
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerPieceMask);
        if (playerInSightRange) {
            getPlayerPiece(transform.position);
            chasing = true;
        }
        if (!chasing) {
            Patrol();
        }
        if (chasing) {
            Chase();
        }
    }

    public void AddDestination(Vector3 destination){
        enemyRoute.Enqueue(destination);
    }

    void getPlayerPiece(Vector3 lastSpot) {
        var collidersInSight = Physics.OverlapSphere(lastSpot, sightRange, playerPieceMask);
        foreach (var collider in collidersInSight) {
            var currentObject = collider.gameObject;
            if (currentObject != null){
                chasePiece = currentObject;
            }
        }

    }

    void Patrol() {
        if (!walkPointSet)
        {
            setEndPoint();
        }

        agent.SetDestination(currentWalkPoint);

        Vector3 distanceToWalkPoint = transform.position - currentWalkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            moveDestination();
        }
    }

    void Chase() {
        Vector3 distanceToWalkPoint = transform.position - chasePiece.transform.position;

        if (distanceToWalkPoint.magnitude < 1f) {
            chasing = false;
            Debug.Log("caught!");
        }
        agent.SetDestination(chasePiece.transform.position);
    }

    void setEndPoint() {
        currentWalkPoint = enemyRoute.Dequeue();
        walkPointSet = true;
    }

    void moveDestination() {
        enemyRoute.Enqueue(currentWalkPoint);
        walkPointSet = false;
            
    }

}
