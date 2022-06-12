using UnityEngine;
using UnityEngine.SceneManagement;

// скрипт для главного меню
public class MainMenu : MonoBehaviour
{
    // загрузка n-ой сцены
    public void OpenScene(int _index){ SceneManager.LoadScene(_index); }

    // закрытие приложения
    public void CloseApp(){ Application.Quit(); }
}