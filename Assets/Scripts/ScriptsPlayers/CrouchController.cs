using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CrouchController : MonoBehaviour
{

    private Animator _animator;
    private Collider2D _collider;

    [SerializeField] private Collider2D standingCollider;
    [SerializeField] private Collider2D crouchingCollider;
    [SerializeField] private Transform antiBugCollider;
    [SerializeField] private LayerMask groundLayer;

    private static readonly int Crouching = Animator.StringToHash("Crouching");
    private static readonly int Grounded = Animator.StringToHash("Grounded");

    const float antiBugRadius = 0.2f; 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Si on clique sur C on va pouvoir crouch, on ne veut pas que crouching soit true pendant un saut
            if (Input.GetKey(KeyCode.C) && (_animator.GetBool(Grounded)))
            {
                _animator.SetBool(Crouching, true);
                //_animator.Play("Crouch-Animation", -1, 0.0f);
                standingCollider.enabled = false;
                crouchingCollider.enabled = true;
            }
            else
            {
                // Vérification pour pouvoir se relever si on est en dessous d'obstacles
                if (Physics2D.OverlapCircle(antiBugCollider.position, antiBugRadius, groundLayer))
                {
                    _animator.SetBool(Crouching, true);
                    //_animator.Play("Crouch-Animation", -1, 0.0f);
                }

                else
                {
                    _animator.SetBool(Crouching, false);
                    standingCollider.enabled = true;
                    crouchingCollider.enabled = false;
                }
            }
        }
    }

}
