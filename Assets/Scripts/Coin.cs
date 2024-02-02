using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private int _nominal = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player == null)
            return;

        player.TakeMoney(_nominal);
        Destroy(gameObject);
    }
}