using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]

public class Collector : MonoBehaviour
{
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TakableObject takable))
        {
            if (takable is Coin)
                _wallet.AddMoney(((Coin)takable).Nominal);
            else if (takable is AidKit)
                _health.TakeHealth(((AidKit)takable).HealthFactor);

            takable.Take();
        }
    }
}