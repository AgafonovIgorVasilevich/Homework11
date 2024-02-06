using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            Vector3 directon = transform.position - enemy.transform.position;
            directon.y = 1;
            _movement.FlyOff(directon);
        }
    }
}