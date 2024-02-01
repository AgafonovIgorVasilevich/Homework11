using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private int _nominal = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wallet wallet = collision.GetComponent<Wallet>();

        if (wallet == null)
            return;

        wallet.AddMoney(_nominal);
        Destroy(gameObject);
    }
}