using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;

    public Action<float, float> OnChangeHealth;

    private float _current;

    private void Start()
    {
        _current = _max;
        OnChangeHealth?.Invoke(_current, _max);
    }

    public void TakeHealth(float value)
    {
        if (value <= 0)
            return;

        if (value + _current > _max)
            _current = _max;
        else
            _current += value;

        OnChangeHealth?.Invoke(_current, _max);
    }

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;

        if (value > _current)
            _current = 0;
        else
            _current -= value;

        if (_current <= 0)
            Die();

        OnChangeHealth?.Invoke(_current, _max);
    }

    private void Die() => Destroy(gameObject);
}