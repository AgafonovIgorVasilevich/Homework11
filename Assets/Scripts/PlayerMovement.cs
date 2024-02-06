using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimator))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private WaitForSeconds _flyDelay = new WaitForSeconds(0.5f);
    private bool _isGround = true;
    private bool _isFly = false;
    private Vector2 _direction;

    private void Update()
    {
        _animator.Stay();

        if (Input.GetAxis(Horizontal) != 0)
            Move();

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground))
            _isGround = ground;
    }

    public void FlyOff(Vector3 direction)
    {
        if (_isFly)
            return;

        StartCoroutine(DelayBetweenFly());

        direction = direction.normalized;
        _rigidbody.AddForce(direction * _jumpForce);
        _animator.Jump();
    }

    private void Move()
    {
        if (_isFly)
            return;

        _animator.Run();
        _direction = _rigidbody.velocity;
        _direction.x = Input.GetAxis(Horizontal) * _speed;
        _rigidbody.velocity = _direction;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
        _animator.Jump();
        _isGround = false;
    }

    private IEnumerator DelayBetweenFly()
    {
        _isFly = true;
        yield return _flyDelay;
        _isFly = false;
    }
}