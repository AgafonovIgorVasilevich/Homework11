using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent (typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _boostFactor = 2;
    [SerializeField] private float _speed = 5;
    [SerializeField] private Eye _eye;

    private EnemyAnimator _animator;
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_eye.IsSeeGround() == false)
            Rotate();

        if (_eye.IsSeeTarget())
            Move(_speed * _boostFactor);
        else
            Move(_speed);
    }

    private void Move(float speed)
    {
        _direction = _rigidbody.velocity;
        _direction.x = speed * _eye.Direction.x;
        _rigidbody.velocity = _direction;
        _animator.Run();
    }

    private void Rotate()
    {
        _animator.Rotate();
        _eye.Rotate();
    }
}
