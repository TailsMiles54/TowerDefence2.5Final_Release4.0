using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// This is so that you can extend the pointer handlers

public class GameManagerScript : MonoBehaviour
{
    [HideInInspector] public int HP = 100;
    [HideInInspector] public int Money = 1000;
    public Text HPbase,Moneyz,NumLeval;
    private SpawnEnemu lvln;
    [HideInInspector]public int scorec = 0;
    private string srak,skak,skar,schet;


    void Update()
    {
        lvln = GameObject.Find("GameMap").GetComponent<SpawnEnemu>();
        
        srak = HP.ToString();
        skak = Money.ToString();
        schet = scorec.ToString(); 
        skar = lvln.LevelNumber.ToString();
        
        NumLeval.color = new Color(255,255,0);
        NumLeval.text = ("Уровень: " + skar + " / " + "Очки: " + schet);
        HPbase.color = new Color(255,255,0);
        HPbase.text = ("Здоровье: " + srak);
        Moneyz.color = new Color(255,255,0);
        Moneyz.text = ("Гроши: " + skak);

        if (HP <= 0)
        {
            Advertisement.Show();
            SceneManager.LoadScene("Menu");
        }
    }
}
