using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// скрипт для внутреигрового пользовательского интерфейса
public class GameUI : MonoBehaviour
{
    // задача полей
    public GameObject finishPanel = null;

    // перезагрузка уровня
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    
    // функция при прохождении уровня игроком
    public void Win(){
        Time.timeScale = 0f;
        finishPanel.GetComponentInChildren<Text>().text = "Вы выбрались!"; 
        finishPanel.SetActive(true);
    }

    // функция при не прохождении уровня игроком
    public void Defeat(){
        Time.timeScale = 0f;
        finishPanel.GetComponentInChildren<Text>().text = "Вы проиграли!" ; 
        finishPanel.SetActive(true);
    }
}