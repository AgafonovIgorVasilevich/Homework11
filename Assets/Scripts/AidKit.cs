using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healthFactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            return;

        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeHealth(_healthFactor);
            Destroy(gameObject);
        }
    }
}