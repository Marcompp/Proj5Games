using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}
