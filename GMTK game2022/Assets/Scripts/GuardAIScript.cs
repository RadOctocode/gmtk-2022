using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAIScript : MonoBehaviour
{
    private int playerPieceMask;
    private bool walkPointSet;
    private bool chasing;
    private bool turnTaken;
    private GameObject chasePiece;
    private NavMeshAgent agent;
    private Vector3 currentWalkPoint;
    private Queue<Vector3> enemyRoute;
    private HeistController heistController;

    public float sightRange;
    // Start is called before the first frame update
    void Start()
    {
        enemyRoute = new Queue<Vector3>();
        agent = GetComponent<NavMeshAgent>();
        heistController = Object.FindObjectOfType<HeistController>();
        playerPieceMask = 1 << 7;
        walkPointSet = false;
        chasing = false;
        turnTaken = false;

        enemyRoute.Enqueue(new Vector3(-6.0f, 0.0f, 5.0f));
        enemyRoute.Enqueue(new Vector3(-2.0f, 0.0f, 6.0f));
        enemyRoute.Enqueue(new Vector3(-2.0f, 0.0f, -6.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (heistController.turn == HeistController.Team.Guards && !turnTaken)
        {
            takeOneGuardTurn();
        }
        if (heistController.turn == HeistController.Team.Thieves)
        {
            turnTaken = false;
        }
    }

    public void AddDestination(Vector3 destination)
    {
        enemyRoute.Enqueue(destination);
    }

    void takeOneGuardTurn()
    {

        getPlayerPiece(transform.position);

        if (chasePiece != null)
        {
            chasing = true;
        }
        if (!chasing)
        {
            Patrol();
        }
        if (chasing)
        {
            Chase();
        }
    }

    void getPlayerPiece(Vector3 lastSpot)
    {
        var collidersInSight = Physics.OverlapSphere(lastSpot, sightRange, playerPieceMask);
        foreach (var collider in collidersInSight)
        {
            var currentObject = collider.gameObject;
            if (currentObject != null && !currentObject.GetComponent<Freeze>().caught)
            {
                chasePiece = currentObject;
            }
            else if (currentObject.GetComponent<Freeze>().caught)
            {
                chasing = false;
                chasePiece = null;
            }
        }

    }

    void Patrol()
    {
        if (!walkPointSet)
        {
            setEndPoint();
        }

        agent.SetDestination(currentWalkPoint);

        Vector3 distanceToWalkPoint = transform.position - currentWalkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            moveDestination();
            turnTaken = true;

        }
    }

    void Chase()
    {
        Collider currentCollider = gameObject.GetComponent<Collider>();
        Collider playerCollider = chasePiece.GetComponent<Collider>();
        Vector3 distanceToWalkPoint = transform.position - chasePiece.transform.position;
        agent.SetDestination(chasePiece.transform.position);

        if (currentCollider.bounds.Intersects(playerCollider.bounds))
        {
            heistController.turn = HeistController.Team.GameOver;
            chasing = false;
            chasePiece.GetComponent<Freeze>().gotCaught();
            chasePiece = null;
            turnTaken = true;
        }
    }

    void setEndPoint()
    {
        currentWalkPoint = enemyRoute.Dequeue();
        walkPointSet = true;
    }

    void moveDestination()
    {
        enemyRoute.Enqueue(currentWalkPoint);
        walkPointSet = false;

    }

}
