using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public partial class JumpController : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody2D _body2D;

    // On récupère les Booleans de l'animator
    private static readonly int Jumping = Animator.StringToHash("Jumping");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int Crouching = Animator.StringToHash("Crouching");


    // Possibilité de modifier sur Unity
    [SerializeField] private float jumpMaxSpeed = 15;
    [SerializeField] private float jumpSpeed = 15;
    [SerializeField] private Transform groundCollider;
    [SerializeField] private LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;


    // On récupère toutes les Components nécessaires.
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    // Fonction qui s'occupe du saut
    private void Jump()
    {
        // On dit qu'on est en l'air
        _animator.Play("Jump-Animation", -1, 0.0f);
        _body2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            PlayerState state = Player.Instance.State;

            // Sert à gérer la transition de l'animation de Jump et de Fall
            float velY = _body2D.velocity.y;
            int v = Mathf.CeilToInt(velY);
            _animator.SetInteger(Jumping, v);

            _animator.SetBool(Grounded, false);
            // Remplacé pour enlever le bug de l'idle pendant le saut
            // if (v != 0)
            //    _animator.SetBool(Grounded, false);
            // else
            //    _animator.SetBool(Grounded, true);


            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCollider.position, groundCheckRadius, groundLayer);
            if (colliders.Length > 0)
            {
                _animator.SetBool(Grounded, true);
                _animator.SetBool(Crouching, false);
            }

            // On vérifie qu'on puisse sauter
            if (Input.GetKeyDown(KeyCode.Space) && state.IsActive && Mathf.Abs(_body2D.velocity.y) <= 0.00001)
                Jump();
        }
    }

    private void FixedUpdate() {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(vel.x, Mathf.Clamp(vel.y, -jumpMaxSpeed, jumpMaxSpeed));
    }
}
