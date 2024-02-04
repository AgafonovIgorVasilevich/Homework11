using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healthFactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeHealth(_healthFactor);
            Destroy(gameObject);
        }
    }
}