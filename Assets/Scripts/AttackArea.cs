using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AttackArea : MonoBehaviour
{
    [SerializeField] private float _damage = 1;

    public float Damage => _damage;
}