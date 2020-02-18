using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;

    [HideInInspector] private EnemyMove EMV;
    // Start is called before the first frame update

    private void Awake()
    {
        EMV = GetComponentInParent<EnemyMove>();
        maxHealth = EMV.EnemyHPMax;
    }

    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = EMV.EnemyHP;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
