using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform startElement;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 pos = startElement.position;
        player.position = new Vector3(startElement.position.x, startElement.position.y, player.position.z);
        Player.Instance.State.IsActive = true;
    }
}
