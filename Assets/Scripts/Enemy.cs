using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour
{
    private EnemyMovement _movement;
    private Health _health;

    private void Start()
    {
        _movement = GetComponent<EnemyMovement>();
        _health = GetComponent<Health>();
    }
}