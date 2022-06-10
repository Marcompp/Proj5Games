using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_level_2 : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("gate_level_2");
        if (other.gameObject.tag == "Player")
        {
            gm.NextScene();
        }
    }
}
