using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Interactable clicked;
    public int layerMask;

    // Update is called once per frame
    public void setObject(Interactable objective) {
        clicked = objective;
    }

    void Start() {
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
