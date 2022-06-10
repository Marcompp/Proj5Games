using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ambiente");
    }

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void StartGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        FindObjectOfType<AudioManager>().Play("Ambiente");
    }
}
