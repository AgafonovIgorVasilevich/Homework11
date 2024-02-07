using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AttackArea : MonoBehaviour
{
    [SerializeField] private float _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
            health.TakeDamage(_damage);
    }
}