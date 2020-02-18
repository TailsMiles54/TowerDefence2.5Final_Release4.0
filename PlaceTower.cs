using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private GameManagerScript GAGA;
    public GameObject Tower;

    [SerializeField] public int towercost = 150; 
    
    private int ct = 0; // count tower
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GAGA = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnMouseUp()
    {
        if ((ct != 1) && (GAGA.Money >= towercost)){
            //Instantiate(Tower, transform.position = transform.position - new Vector3 (0,0,0), Quaternion.identity);
            var bow = Instantiate(Tower).transform;
            bow.localPosition = transform.position + new Vector3 (0,0,-1);
            ct = 1;
            GAGA.Money = GAGA.Money - towercost;
        }
    }
    
    
}
    