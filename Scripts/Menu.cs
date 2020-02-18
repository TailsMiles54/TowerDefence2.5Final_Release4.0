using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float timer;
    public bool ispuse;
    public bool guipuse;

    public void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = Screen.width / 70;
        Cursor.visible = true;// включаем отображение курсора
        if (GUI.Button(new Rect((float)(Screen.width / 6)*2.5f, (float)(Screen.height / 10)*2, Screen.width / 6, Screen.width / 12), "Новая игра", myButtonStyle))
        {
            SceneManager.LoadScene("Level1");
        }
        if (GUI.Button(new Rect((float)(Screen.width / 6)*2.5f, (float)(Screen.height / 10)*4, Screen.width / 6, Screen.width / 12), "Посмотреть рекламу", myButtonStyle))
        {
            Advertisement.Show();
        }
        if  (GUI.Button(new Rect((float)(Screen.width / 6)*2.5f, (float)(Screen.height / 10)*6, Screen.width / 6, Screen.width / 12), "Выйти", myButtonStyle))
        {
            Application.Quit();
        }
    }
}