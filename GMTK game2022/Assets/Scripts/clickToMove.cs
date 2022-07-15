using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Interactable clicked;

    // Update is called once per frame
    public void setObject(Interactable objective) {
        clicked = objective;
    }

    void Start() {
        clicked = null;
    }

    void Update()
    {
        if(/*Input.GetMouseButtonDown(1)*/clicked != null){
            Ray movePosition = Camera.main.ScreenPointToRay(clicked.transform.position);
            if(Physics.Raycast(movePosition, out var hitInfo)){
                agent.SetDestination(hitInfo.point);
                Debug.Log(hitInfo.point);
            }
        }
    }

}
