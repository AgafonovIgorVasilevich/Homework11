using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _damage = 1;

    public float Damage => _damage;

    private PlayerMovement _movement;
    private Health _health;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Vector3 directon = transform.position - enemy.transform.position;
            directon.y = 1;
            _movement.FlyOff(directon);
        }
    }

    public void TakeDamage(float value)
    {
        _health.TakeDamage(value);
    }
}