using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemu : MonoBehaviour
{
    private int i=0;
    [HideInInspector] public int LevelNumber=1;
    public GameObject[] waypoints;
    
    [HideInInspector] public int lvlcol = 10;

    public GameObject testEnemyPrefab;

    private EnemyMove QAQA;


    // Start is called before the first frame update
    
    private void Awake()
    {
        QAQA = testEnemyPrefab.GetComponent<EnemyMove>();

        QAQA.EnemyHPMax = 100;
    }
    
    void Start()
    {
        StartCoroutine("EnemySpawn");
        LevelNumber = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator EnemySpawn()
    {
        for (;;LevelNumber++){
            for (; i <= lvlcol; i++)
            {
                Instantiate(testEnemyPrefab, new Vector3( 999, 999, -999), Quaternion.identity).GetComponent<EnemyMove>().waypoints = waypoints;
                yield return new WaitForSeconds(0.8f);
            }
            yield return new WaitForSeconds(20f);
            QAQA.EnemyHPMax = QAQA.EnemyHPMax + 50;
            i = 0;
        }
    }
}
