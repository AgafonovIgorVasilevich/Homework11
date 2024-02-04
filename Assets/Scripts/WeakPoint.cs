using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    [SerializeField] private int _damageFactor;
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
            _health.Substract(_damageFactor * player.Damage);
    }
}