using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeistController : MonoBehaviour
{
    public enum Team
    {
        Thieves,
        Guards,
    };

    public Team turn;
    ActionPointHandler[] actionPoints;
    public ClickToMove ActivePlayer;

    // Start is called before the first frame update
    void Start()
    {
        turn = Team.Thieves;
        actionPoints = Object.FindObjectsOfType<ActionPointHandler>();
    }

    public void NextTurn()
    {
        switch (turn)
        {
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

    public void SelectActivePlayer(ClickToMove input)
    {
        ActivePlayer = input;
    }

    public void UnsetActivePlayer()
    {
        ActivePlayer = null;
    }
}
