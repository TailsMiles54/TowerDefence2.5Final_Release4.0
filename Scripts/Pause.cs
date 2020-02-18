using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool ispuse;
    public bool guipuse;
    

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false)
        {
            ispuse = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
        {
            ispuse = false;
        }
        if (ispuse == true)
        {
            timer = 0;
            guipuse = true;
        }
        else if (ispuse == false)
        {
            timer = 1f;
            guipuse = false;

        }
    }
    public void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 30;
        
        
        if (guipuse == true)
        {
            Cursor.visible = true;// включаем отображение курсора
            if (GUI.Button(new Rect((float)(Screen.width / 6)*2.5f, (float)(Screen.height / 10)*2, Screen.width / 6, Screen.width / 12), "Продолжить", myButtonStyle))
            {
                ispuse = false;
                timer = 0;
                Cursor.visible = false;
            }
            if (GUI.Button(new Rect((float)(Screen.width / 6)*2.5f, (float)(Screen.height / 10)*4, Screen.width / 6, Screen.width / 12), "В Меню", myButtonStyle))
            {
                ispuse = false;
                timer = 0;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}