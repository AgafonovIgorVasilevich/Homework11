using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent (typeof(Wallet))]
[RequireComponent (typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    public int Damage => _damage;

    private PlayerMovement _movement;
    private Wallet _wallet;
    private Health _health;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();
        
        if (enemy == null)
            return;

        Vector3 directon = transform.position - enemy.transform.position;
        directon.y = 1;
        _movement.FlyOff(directon);
    }

    public void TakeHealth(int value)
    {
        _health.Add(value);
    }

    public void TakeDamage(int value)
    {
        _health.Substract(value);
    }

    public void TakeMoney(int value)
    {
        _wallet.AddMoney(value);
    }
}