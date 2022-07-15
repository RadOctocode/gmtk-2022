using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Update is called once per frame
    /*   void Update(){
           if (Input.GetMouseButtonDown(0)){
               var hit RaycastHit;
               var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

               if (Physics.Raycast(ray, hit)){
                   if (hit.transform.name == "Interactable") Debug.Log("My object is clicked by mouse");
               }
           }
   }*/

    void OnMouseDown()
    {
        GameObject activePlayer = GameObject.Find("player");
        activePlayer.GetComponent<clickToMove>().setObject(this);
        Debug.Log(transform.position);
    }
}