using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(Wallet))]

public class Collector : MonoBehaviour
{
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet> ();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
            _wallet.AddMoney(coin.Nominal);

        if(collision.TryGetComponent(out AidKit aidKit))
            _health.TakeHealth(aidKit.HealthFactor);

        if (collision.TryGetComponent(out TakableObject takable))
            takable.Take();
    }
}