using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeistController : MonoBehaviour
{
    public enum Team {
        Thieves,
        Guards,
    };

    public Team turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = Team.Thieves;
    }

    void NextTurn()
    {
        switch (turn) {
            case Team.Thieves:
            Debug.Log("Move to Guards' turn");
            turn = Team.Guards;
            break;
            case Team.Guards:
            Debug.Log("Move to Thieves' turn");
            turn = Team.Thieves;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
