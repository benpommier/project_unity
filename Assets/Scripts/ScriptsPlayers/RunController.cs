using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class RunController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body2D;
    private SpriteRenderer _sprite;

    // On récupère le Boolean de l'animator
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Crouching = Animator.StringToHash("Crouching");


    // maxSpeed et speed de notre Player puis savoir gérer la vitesse si on est acccroupi ou non
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;

    // On récupère toutes les Components nécessaires.
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private int GetSpeedLimit()
    {
        // Si on est accroupi on est moins rapide !
        if (_animator.GetBool(Crouching))
        {
            return 3;
        }
        return 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            PlayerState state = Player.Instance.State;
            Vector2 vel = _body2D.velocity;

            // Si on termine le niveau, on peut plus bouger
            if (state.IsActive)
            {
                Move();
            }
            else
            {
                _animator.SetBool(Running, false);
            }

            // Stop les glissades
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Q))
            {
                _body2D.velocity = new Vector2(0, vel.y);
            }
        }
    }

    // Fonction qui gère les mouvements 
    public void Move()
    {
        _animator.SetBool(Running, Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q));        

        if (Input.GetKey(KeyCode.D))
        {
            _sprite.flipX = false;
            _body2D.AddForce(new Vector2(speed / GetSpeedLimit(), 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            _sprite.flipX = true;
            _body2D.AddForce(new Vector2(-speed / GetSpeedLimit(), 0), ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(Mathf.Clamp(vel.x, -maxSpeed / GetSpeedLimit(), maxSpeed / GetSpeedLimit()), vel.y);
    }
}
