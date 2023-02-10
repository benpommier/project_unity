using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject exitIndicator;
    [SerializeField] private SceneType Scene;

    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private bool dead = false;

    private void RestartLevel()
    {
        SceneManager.LoadScene((int) Scene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Animator>().SetBool(IsDead, true);
            other.gameObject.GetComponent<Animator>().Play("Hurt-Animation", -1, 0.0f);
            Invoke("Display", 0.3f);
            dead = true;
        }
    }

    private void Display()
    {
        exitIndicator.SetActive(true);
        Player.Instance.State.IsActive = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && dead)
            RestartLevel();
    }
}
