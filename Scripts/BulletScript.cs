using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float lastWaypointSwitchTime;
    private GameObject[] Tawer;
    public float speed = 1f;
    private TowerController shootscript;
    public int damageq = 20;

    private GameObject jopa;

    [HideInInspector] public EnemyMove QWER;

    private float distance;
    private float startsTime;

    void Start()
    {
        Tawer = GameObject.FindGameObjectsWithTag("Tower");

        for (int i = 0; i < Tawer.Length; i++)
        {
            if (Vector3.Distance (Tawer[i].transform.position,gameObject.transform.position) <= 1)
            {
                shootscript = Tawer[i].GetComponent<TowerController>();
            }
        }
        
        
        
        jopa = shootscript.Targeta;
        
        lastWaypointSwitchTime = Time.time;
    
        
    }
    
    void Update()
    {
        if (jopa != null)
        {
            QWER = jopa.GetComponent<EnemyMove>();
            Vector3 endPosition = jopa.transform.position;
             float pathLength = Vector3.Distance (gameObject.transform.position, endPosition);
             float totalTimeForPath = pathLength / speed;
             float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
             gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, endPosition, currentTimeOnPath / totalTimeForPath);
             transform.LookAt(jopa.transform, Vector3.forward);
            if (gameObject.transform.position == jopa.transform.position)
            {
                Destroy(gameObject);
                QWER.EnemyHP = QWER.EnemyHP - damageq;
            }
        }

        if (jopa == null)
        {
            Destroy(gameObject);
        }
    }
}
