using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [HideInInspector] public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    [HideInInspector] public float speed;
    private GameManagerScript GAMA;
    private int Nagrada = 50;
    private int SCORE = 10;

    public float EnemyHPMax;
    
    public float EnemyHP;
    // Start is called before the first frame update

    void Start()
    {
        GAMA = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        speed = 1f;
        lastWaypointSwitchTime = Time.time;
        EnemyHP = EnemyHPMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 startPosition = waypoints [currentWaypoint].transform.position;
        Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;
        
        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        
        if (gameObject.transform.position == endPosition) 
            {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
            }
            else
            {
                GAMA.HP = GAMA.HP - 5;
                Destroy(gameObject);
            }
        }

        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
            GAMA.Money += Nagrada;
            GAMA.scorec += SCORE;
        }

        Vector3 direction = gameObject.transform.position - waypoints [currentWaypoint].transform.position;   //
        gameObject.transform.rotation = Quaternion.AngleAxis(                               // Взял из интернета, пока хз как работает
        Mathf.Atan2 (direction.y, direction.x) * 180 / Mathf.PI,                            //
        new Vector3 (0, 0, 1));
    }
}
