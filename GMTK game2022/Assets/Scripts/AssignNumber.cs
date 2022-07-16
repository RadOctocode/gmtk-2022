using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignNumber : MonoBehaviour
{
    private int playerPieceMask = 1 << 7;

    private int NO_SIDE_CONNECTED = 0;
    private int ONE_SIDE_CONNECTED = 1;
    private int BOTH_SIDES_CONNECTED = 2;
    private int connectionStatus;
    private ActionPointHandler gamePieceActionPoints;

    public int maxNum;
    void Start(){
        connectionStatus = NO_SIDE_CONNECTED;

    }

    void Update(){
        if (connectionStatus == ONE_SIDE_CONNECTED) {

            if (Input.GetMouseButtonDown(0))
            {
                Ray clickPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(clickPosition, out var hitInfo, Mathf.Infinity, playerPieceMask))
                {
                    gamePieceActionPoints = hitInfo.transform.gameObject.GetComponent<ActionPointHandler>();
                    connectionStatus = BOTH_SIDES_CONNECTED;

                }
            }

        }

        if (connectionStatus == BOTH_SIDES_CONNECTED){
            gamePieceActionPoints.setActionPoints(Roll());
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown(){
        if (connectionStatus == NO_SIDE_CONNECTED) {
            connectionStatus = ONE_SIDE_CONNECTED;
        }
    }

    int Roll() {
        return Random.Range(1, maxNum);
    }
}
