using UnityEngine;
using TMPro;

public class CoinUIPrinter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textbox;

    private void OnEnable()
    {
        CollectableState state = Player.Instance.CollectableState;
        state.OnCoinCountUpdate += OnCoinCountUpdate;
    }

    private void OnDisable()
    {
        CollectableState state = Player.Instance.CollectableState;
        state.OnCoinCountUpdate += OnCoinCountUpdate;
    }

    private void OnCoinCountUpdate(int coinCount)
    {
        textbox.text = coinCount.ToString();
    }
}
