using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
            player.TakeDamage(_damage);
    }
}