using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private bool _isWeakPoint;
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            if (_isWeakPoint)
                _enemy.TakeDamage(player.Damage);
            else
                player.TakeDamage(_enemy.Damage);
        }
    }
}