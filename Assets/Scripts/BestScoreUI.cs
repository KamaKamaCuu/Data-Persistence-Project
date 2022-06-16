using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScoreUI : MonoBehaviour
{
    public Text bestScore;

    private void Awake()
    {
        if (GameManager.Instance.maxUsername != null && GameManager.Instance.maxScore > 0)
        {
            bestScore.text = GameManager.Instance.maxUsername + " " + GameManager.Instance.maxScore + " " + GameManager.Instance.date;
        }
        else
        {
            bestScore.text = "Best score still unassigned!";
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
