using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string GoJump = nameof(GoJump);
    private const string IsRun = nameof(IsRun);

    private SpriteRenderer _sprite;
    private Animator _animator;

    public void Jump()
    {
        _animator.SetTrigger(GoJump);
    }

    public void Run()
    {
        _animator.SetBool(IsRun, true);
    }

    public void Stay()
    {
        _animator.SetBool(IsRun, false);
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
            RotateSprite();
    }

    private void RotateSprite()
    {
        _sprite.flipX = Input.GetAxis(Horizontal) < 0;
    }
}