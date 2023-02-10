using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class BatFly : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private float animationDurationInSeconds;
    [SerializeField] private AnimationCurve _curve;

    private Animator animator;
    private static readonly int NeedToFly = Animator.StringToHash("NeedToFly");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool(NeedToFly, true);
            StartCoroutine(WaitingEndsOfScreenCoroutine());
        }
    }

    public IEnumerator WaitingEndsOfScreenCoroutine()
    {
        Vector3 start = transform.position;
        float elapsed = .0f;
        float delta = 0.0f;

        while (delta <= 1.0f)
        {
            delta = elapsed / animationDurationInSeconds;
            transform.position = Vector3.Lerp(start, target, _curve.Evaluate(delta));
            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
