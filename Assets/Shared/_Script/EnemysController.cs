using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.U2D;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemysController : MonoBehaviour
{
    
    [SerializeField]private GameObject _enemy;
    [SerializeField]private List<GameObject> _EnemyPos = new List<GameObject>();
    private List<GameObject> _listEnemys = new List<GameObject>();

    void NewEnemy(GameObject enemy,GameObject enemyPOS, bool right) {
        GameObject i = Instantiate(enemy, enemyPOS.transform.position, Quaternion.identity);
        _listEnemys.Add(i);
        if (right)
        {
            i.GetComponent<SpriteRenderer>().flipX = true;	
        }
    }

}
