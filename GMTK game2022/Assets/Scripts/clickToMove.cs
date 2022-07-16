using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    Animator animatorController;
    NavMeshAgent agent;
    int interactiveLayer;
    int playerLayer;
    HeistController heistController;
    bool isSneaking = false;

    void Start()
    {
        animatorController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        interactiveLayer = 1 << 6;
        playerLayer = 1 << 7;
        heistController = Object.FindObjectOfType<HeistController>();
    }

    void Update()
    {
        if (heistController.turn == HeistController.Team.Thieves)
        {
            OnThiefInputs();
        }
    }

    void OnThiefInputs()
    {
        if (heistController.activeInput == null)
        {
            HandlePlayerSelection();
        }
        else if (heistController.activeInput == this)
        {
            HandlePlayerAction();
        }
    }

    void HandlePlayerSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CastAtClick(out var hitInfo, playerLayer))
            {
                Debug.Log($"Player selection hit: {hitInfo}");
                if (hitInfo.transform.gameObject == gameObject)
                {
                    Debug.Log($"Setting active player input {name}");
                    heistController.activeInput = this;
                }
            }
        }
    }

    void HandlePlayerAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Unsetting active player input {name}");
            heistController.activeInput = null;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (CastAtClick(out var hitInfo, interactiveLayer))
            {
                isSneaking = true;
                agent.SetDestination(hitInfo.point);
            }
        }
        if (agent.remainingDistance <= agent.stoppingDistance) {
            isSneaking = false;
        } else {
            isSneaking = true;
        }
        animatorController.SetBool("sneak", isSneaking);
    }

    bool CastAtClick(out RaycastHit hitInfo, int layer)
    {
        Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("mouse position " + Input.mousePosition);
        return Physics.Raycast(movePosition, out hitInfo, Mathf.Infinity, layer);
    }
}
