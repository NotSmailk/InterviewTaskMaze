using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject finishPanel = null;

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    
    public void Win()
    {
        Time.timeScale = 0f;
        finishPanel.GetComponentInChildren<Text>().text = "Вы выбрались!"; 
        finishPanel.SetActive(true);
    }

    public void Defeat()
    {
        Time.timeScale = 0f;
        finishPanel.GetComponentInChildren<Text>().text = "Вы проиграли!" ; 
        finishPanel.SetActive(true);
    }
}