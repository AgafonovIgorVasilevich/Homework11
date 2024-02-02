using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        player.TakeDamage(_damage);
    }
}