using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    Interactable clicked;
    int layerMask;

    // Update is called once per frame
    public void setObject(Interactable objective) {
        clicked = objective;
    }

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        clicked = null;
        layerMask = 1 << 6;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("mouse position " + Input.mousePosition);
            if(Physics.Raycast(movePosition, out var hitInfo, Mathf.Infinity, layerMask)){
                agent.SetDestination(hitInfo.point);
            }
        }
    }

}
