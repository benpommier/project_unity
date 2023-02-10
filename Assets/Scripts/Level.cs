using UnityEngine;
using UnityEngine.SceneManagement;


public enum SceneType
{
    MainMenu = 0,
    Tutorial = 1,
    SecondLevel = 2,
}

public class Level : MonoBehaviour
{
    [SerializeField] private SceneType Scene;

    public void GoToNextLevel() {
        SceneManager.LoadScene((int) Scene);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GoToNextLevel();
    }
}
