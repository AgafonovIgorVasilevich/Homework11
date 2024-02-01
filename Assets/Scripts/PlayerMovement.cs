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

    private bool _isGround = true;
    private Vector2 _direction;

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();
    }

    private void Move()
    {
        _direction = _rigidbody.velocity;
        _direction.x = Input.GetAxis(Horizontal) * _speed;
        _rigidbody.velocity = _direction;

        if (Mathf.Abs(_direction.x) > 0)
            _animator.Run();
        else
            _animator.Stay();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
        _animator.Jump();
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
    }
}
