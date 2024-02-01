using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof (Animator))]

public class EnemyAnimator : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);

    private SpriteRenderer _sprite;
    private Animator _animator;

    public void Run()
    {
        _animator.SetBool(IsRun, true);
    }

    public void Stay()
    {
        _animator.SetBool (IsRun, false);
    }

    public void LookAt(Vector3 target)
    {
        _sprite.flipX = target.x > transform.position.x;
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
}