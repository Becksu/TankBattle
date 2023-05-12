using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    MainMenu,
    Gameplay,
    GamePause,
    GameWin,
    GameLose,
    None

}
public class GameManager : Singleton<GameManager>
{
    public GameState gameState;

    public void ChanggGameState(GameState state)
    {
        gameState = state;
    }
    public bool IsStateGame(GameState state)
    {
        return gameState == state;
    }
}
