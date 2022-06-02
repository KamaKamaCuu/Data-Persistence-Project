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
        if(GameManager.Instance.username != null && GameManager.Instance.maxScore > 0)
        {
            username.text = "Best score: " + GameManager.Instance.username + " : " + GameManager.Instance.maxScore;
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
