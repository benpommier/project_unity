using UnityEngine;

public class EndPosition : MonoBehaviour
{
    // [SerializeField] private GameObject exitIndicator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // exitIndicator.SetActive(true);
            Player.Instance.State.IsActive = false;
        }
    }

}
