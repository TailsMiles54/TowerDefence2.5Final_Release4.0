using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Bullet;
    private GameObject[] Enemy;

    [HideInInspector]public GameObject Targeta;
    private GameObject[] _gameObjects;
    private GameObject[] obnul;

    [SerializeField]
    public int AttackRange = 3;

    private float starttime;
    private float endtime;
    private void Awake()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Start()
    {
        starttime = 0;
        
    }

    void Update()
    {
        _gameObjects = null;
        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy = _gameObjects;
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i] != null)
            {
                if (Vector3.Distance(gameObject.transform.position, Enemy[i].transform.position) <= AttackRange) 
                {
                    Vector3 direction = gameObject.transform.GetChild(0).position - Enemy[i].transform.position; //
                    gameObject.transform.rotation = Quaternion.AngleAxis( // Поворот на противника
                        Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, //
                        new Vector3(0, 0, 1));
                    Targeta = Enemy[i]; // переменная для передачи в снаряд
                    
                    endtime = Time.time;
                    
                    if (endtime - starttime > 1f)
                    {
                        var bow = Instantiate(Bullet).transform;
                        bow.localPosition = gameObject.transform.position + new Vector3 (0,0,1);
                        starttime = Time.time;
                    }

                    break;
                }

                if (Vector3.Distance(gameObject.transform.position, Enemy[i].transform.position) > AttackRange)
                {
                    continue;
                }
            }

            if (Enemy[i] == null)
            {
                continue;
            }
        }
    }
}