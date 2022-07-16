using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    int interactiveLayer;
    int playerLayer;
    HeistController heistController;
    Highlight _highlighter;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        interactiveLayer = 1 << 6;
        playerLayer = 1 << 7;
        heistController = Object.FindObjectOfType<HeistController>();
        _highlighter = GetComponent<Highlight>();
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
        if (heistController.ActivePlayer == null)
        {
            HandlePlayerSelection();
        }
        else if (heistController.ActivePlayer == this)
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
                    heistController.SelectActivePlayer(this);
                }
            }
        }
    }

    void HandlePlayerAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Unsetting active player input {name}");
            _highlighter.Highlighted = false;
            heistController.UnsetActivePlayer();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (CastAtClick(out var hitInfo, interactiveLayer))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }

    bool CastAtClick(out RaycastHit hitInfo, int layer)
    {
        Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("mouse position " + Input.mousePosition);
        return Physics.Raycast(movePosition, out hitInfo, Mathf.Infinity, layer);
    }

    void OnMouseOver()
    {
        if (heistController.ActivePlayer == null)
        {
            _highlighter.Highlighted = true;
        }
    }

    void OnMouseExit()
    {
        if (heistController.ActivePlayer == null)
        {
            _highlighter.Highlighted = false;
        }
    }
}
