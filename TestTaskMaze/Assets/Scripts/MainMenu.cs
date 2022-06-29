using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenScene(int _index)
    { 
        SceneManager.LoadScene(_index); 
    }

    public void CloseApp()
    { 
        Application.Quit(); 
    }
}