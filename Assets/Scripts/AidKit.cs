using UnityEngine;

[RequireComponent (typeof(Collider2D))]

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healthFactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player == null)
            return;

        player.TakeHealth(_healthFactor);
        Destroy(gameObject);
    }
}