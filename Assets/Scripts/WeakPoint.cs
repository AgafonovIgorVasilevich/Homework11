using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    [SerializeField] private int _damageFactor;
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        _health.Substract(_damageFactor * player.Damage);
    }
}