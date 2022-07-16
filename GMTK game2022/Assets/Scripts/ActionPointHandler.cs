using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointHandler : MonoBehaviour
{
    public int actionPoints;
    public int maxNum;
    public bool noPoints;
    // Start is called before the first frame update
    void Start(){
        actionPoints = 0;
        noPoints = false;
    }

    void Update() {
        if (actionPoints <= 0) {
            noPoints = true;
        }
    }

    void deductActionPoint() {
        actionPoints = actionPoints - 1;
    }

    public void setActionPoints(int setPoints) {
        actionPoints = setPoints;
    }

}
