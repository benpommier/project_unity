using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform teleportElement;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vector3 pos = teleportElement.position;
        player.position = new Vector3(teleportElement.position.x, teleportElement.position.y, player.position.z);
        Player.Instance.State.IsActive = true;
    }
}