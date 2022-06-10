using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveController : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("COLLIDER");
        if (col.gameObject.CompareTag("Player"))
        {
            gm.NextScene();
        }
        
    }
}
