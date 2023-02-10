using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    private static readonly string CoinTag = "Coin";
    // On colid get the item, store, animate and count the item.
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (!item.CompareTag(CoinTag)) return;

        CollectableState state = Player.Instance.CollectableState;
        CoinScenarioForEnd scenarioForEnd = CoinScenarioForEnd.Instance;

        var diamondComponent = item.GetComponent<Coin>();

        if (diamondComponent.TryCollect(out int collectedCount))
        {
            state.CoinCount += collectedCount;
            scenarioForEnd.ChooseScenario(state.CoinCount);
        }
    }

}
