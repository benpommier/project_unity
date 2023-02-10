using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneType Scene;

    public void PlayGame()
    {
        SceneManager.LoadScene((int) Scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
