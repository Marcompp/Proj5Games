using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.U2D;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemysController : MonoBehaviour
{
    
    [SerializeField]private GameObject _enemy;
    [SerializeField]private List<GameObject> _EnemyPosRight = new List<GameObject>();
    [SerializeField]private List<GameObject> _EnemyPosLeft = new List<GameObject>();
    private List<GameObject> _listEnemys = new List<GameObject>();
    void Start(){
        for(int i = 0; i < _EnemyPosRight.Count; i++){
            NewEnemy(_enemy, _EnemyPosRight[i],true);
        }
        for(int i = 0; i < _EnemyPosLeft.Count; i++){
            NewEnemy(_enemy, _EnemyPosLeft[i],true);
        }
    }
    void NewEnemy(GameObject enemy,GameObject enemyPOS, bool right) {
        GameObject i = Instantiate(enemy, enemyPOS.transform.position, Quaternion.identity);
        _listEnemys.Add(i);
        if (right)
        {
            i.GetComponent<Enemy>().isFacingRight = true;	
        }
    }

}