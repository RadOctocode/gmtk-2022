using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointHandler : MonoBehaviour
{
    public int actionPoints;
    public int maxNum;

    void Start()
    {
        actionPoints = 0;
    }

    void Update()
    {
    }

    bool HasNoPoints()
    {
        return actionPoints <= 0;
    }

    void deductActionPoint()
    {
        actionPoints = actionPoints - 1;
    }

    public void setActionPoints(int setPoints)
    {
        actionPoints = setPoints;
    }

}
