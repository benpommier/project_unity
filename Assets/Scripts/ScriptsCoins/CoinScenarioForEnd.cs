using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScenarioForEnd : MonoBehaviour
{
    public static CoinScenarioForEnd Instance { get; private set; }
    private BoxCollider2D _boxCollider;
    private bool HasBeenVisited;

    [SerializeField] private GameObject infoVictory;
    [SerializeField] private GameObject infoNotTheEnd;
    [SerializeField] private int _coinNumberToSaveFriend;
    [SerializeField] private SceneType Scene;


    public int coinsNumberToOpen => _coinNumberToSaveFriend;
    public bool victoryOrDefeat = false;
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private bool dead = false;


    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void ChooseScenario(int CoinCount)
    {
        if (CoinCount >= _coinNumberToSaveFriend)
            victoryOrDefeat = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && victoryOrDefeat && !HasBeenVisited)
        {
            infoVictory.SetActive(true);
            _boxCollider.enabled = false;
            HasBeenVisited = true;
        }
        else if (other.gameObject.CompareTag("Player") && !victoryOrDefeat)
        {
            infoNotTheEnd.SetActive(true);
            other.gameObject.GetComponent<Animator>().SetBool(IsDead, true);
            other.gameObject.GetComponent<Animator>().Play("Hurt-Animation", -1, 0.0f);
            Invoke("Display", 0.3f);
            dead = true;
        }
    }

    private void Display()
    {
        Player.Instance.State.IsActive = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            infoNotTheEnd.SetActive(false);
            infoVictory.SetActive(false);
        }
        if (Input.GetKey(KeyCode.R) && dead)
            RestartLevel();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene((int)Scene);
    }

}
