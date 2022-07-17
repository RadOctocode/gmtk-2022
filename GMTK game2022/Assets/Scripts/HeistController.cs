using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeistController : MonoBehaviour
{
    public enum Team
    {
        Thieves,
        Guards,
        GameOver,
        RollingStats,
    };

    public GameOverScript gameOverScreen;
    public Team turn;
    ActionPointHandler[] _actionPoints;
    GuardAIScript[] _guards;
    public ClickToMove ActivePlayer;
    public GameObject Dice;

    // Start is called before the first frame update
    void Start()
    {
        turn = Team.RollingStats;
        _actionPoints = Object.FindObjectsOfType<ActionPointHandler>();
        _guards = Object.FindObjectsOfType<GuardAIScript>();
        gameOverScreen = Object.FindObjectOfType<GameOverScript>();
        gameOverScreen.Unset();
    }

    void Update()
    {
        switch (turn)
        {
            case Team.GameOver:
                EndGame();
                break;
            case Team.Thieves:
                DoThievesTurn();
                break;
            case Team.Guards:
                DoGuardsTurn();
                break;
            case Team.RollingStats:
                RollStats();
                break;
        }
    }

    void DoThievesTurn()
    {
        if (_actionPoints.All(action => action.actionPoints <= 0))
        {
            NextTurn();
        }
    }

    void DoGuardsTurn()
    {
        if (_guards.All(guard => guard.TurnTaken))
        {
            NextTurn();
        }
    }

    void RollStats()
    {
        if (_actionPoints.All(action => action.actionPoints > 0))
        {
            NextTurn();
        }
    }

    void EndGame()
    {
        Debug.Log("Ending game");
        gameOverScreen.Setup();
    }

    public void NextTurn()
    {
        switch (turn)
        {
            case Team.RollingStats:
                Debug.Log("Stats are rolled, moving to start with Thieves");
                turn = Team.Thieves;
                break;
            case Team.Thieves:
                Debug.Log("Move to Guards' turn");
                turn = Team.Guards;
                break;
            case Team.Guards:
                Debug.Log("Move to roll");
                Instantiate(Dice, new Vector3(-18, 1, 0), Quaternion.identity);
                turn = Team.RollingStats;
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
