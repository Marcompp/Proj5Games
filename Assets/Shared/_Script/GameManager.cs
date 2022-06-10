using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.U2D;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public int level;
    public int hp;
    public bool reset;

    private static GameManager _instance;
    private string[] scenePaths = {"Scene1/Scene1","Scene2/Scene2","Scene3/Scene3"};
    
    [SerializeField]private GameObject _enemy;
    [SerializeField]private List<GameObject> _EnemyPos = new List<GameObject>();
    private List<GameObject> _listEnemys = new List<GameObject>();


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
        level = 3;
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

    public void ResetScene()
    {
        Debug.Log("ououo");
        SceneManager.LoadScene(scenePaths[level-1], LoadSceneMode.Single);
        ChangeState(GameState.GAME);
        hp = 10;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(scenePaths[level], LoadSceneMode.Single);
        level+=1;
    }


    private void Reset()
    {
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        hp = 10;
        level = 1;
    }

}
