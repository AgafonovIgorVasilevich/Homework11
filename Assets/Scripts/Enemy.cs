using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage = 1;

    private Health _health;

    public float Damage => _damage;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage(float value)
    {
        _health.TakeDamage(value);
    }
}