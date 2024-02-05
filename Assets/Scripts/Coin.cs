using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private int _nominal = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddMoney(_nominal);
            Destroy(gameObject);
        }
    }
}