using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerState _state;
    public static Player Instance { get; private set; }
    public PlayerState State => _state;

    // Initialisation du système d'item
    private CollectableState _collectableState;
    public CollectableState CollectableState => _collectableState;
    private void Awake()
    {
        Instance = this;
        _collectableState = new CollectableState();
        _state = new PlayerState()
        {
            IsGrounded = true,
            IsJumping = false,
            IsStagger = false
        };
    }
}