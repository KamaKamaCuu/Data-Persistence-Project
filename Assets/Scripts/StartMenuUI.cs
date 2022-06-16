using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    public Text username;

    private void Awake()
    {       
        if(GameManager.Instance.maxUsername != null && GameManager.Instance.maxScore > 0)
        {
            username.text = "Best score: " + GameManager.Instance.maxUsername + " : " + GameManager.Instance.maxScore;
        }
        else
        {
            username.text = "Best score still unassigned!";
        }
    }

    public void StartGame()
    {
        GameManager.Instance.username = username.text;        
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); 
        #endif
    }
}
