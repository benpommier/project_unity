using System;

public class PlayerState
{
    private bool _jumping;

    public bool IsActive { get; set; } = true;
    public bool IsGrounded { get; set; }
    public bool IsStagger { get; set; }
    public bool IsJumping
    {
        get => _jumping;
        set
        {
            _jumping = value;
            if (_jumping)
            {
                OnJumping?.Invoke();
            }
        }
    }

    #region EVENTS
    public event Action OnJumping;
    // public event Action<bool> OnIsGroundedUpdate;
    #endregion
}
