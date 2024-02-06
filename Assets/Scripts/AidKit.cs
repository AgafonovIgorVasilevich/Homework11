using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AidKit : TakableObject
{
    [SerializeField] private int _healthFactor;

    public int HealthFactor => _healthFactor;
}