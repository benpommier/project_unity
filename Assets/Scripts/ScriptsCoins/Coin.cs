using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    [SerializeField] private int count;
    // [SerializeField] private float animationDurationInSeconds;

    private bool collected;
    public int Count => count;
    // private static readonly int CollectedAnimHash = Animator.StringToHash("DiamondCatch");

    public bool TryCollect(out int collectedCount)
    {
        collectedCount = -1;
        // animate and le degager
        if (collected) return false;

        collectedCount = Count;
        // OnCollected();
        GetComponent<SpriteRenderer>().enabled = false;
        return (collected = true);
    }
}