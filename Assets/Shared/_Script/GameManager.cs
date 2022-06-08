using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public int level;
    public int hp;
    public bool reset;

    private static GameManager _instance;


    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
           _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        hp = 10;
        level = 1;
        reset = false;
        gameState = GameState.MENU;
        Time.timeScale = 0;
    }

    
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (gameState == GameState.ENDGAME && nextState == GameState.GAME) {
            Time.timeScale = 1;
            Reset();
            reset = true;
        }
        if (gameState == GameState.ENDGAME && nextState == GameState.MENU) {
            Reset();
            reset = true;
        }
        if (gameState == GameState.MENU && nextState == GameState.GAME) {
            Time.timeScale = 1;
        }
        if (gameState == GameState.GAME && nextState == GameState.PAUSE) {
            Time.timeScale = 0;
        }
        if (gameState == GameState.GAME && nextState == GameState.ENDGAME) {
            Time.timeScale = 0;
        }
        if (gameState == GameState.PAUSE && nextState == GameState.GAME) {
            Time.timeScale = 1;
        }
        if (gameState == GameState.PAUSE && nextState == GameState.MENU) {
            Reset();
            reset = true;
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        hp = 10;
        level = 0;
    }

}
