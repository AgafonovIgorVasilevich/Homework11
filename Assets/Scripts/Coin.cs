using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Coin : TakableObject
{
    [SerializeField] private int _nominal = 1;

    public int Nominal => _nominal;
}