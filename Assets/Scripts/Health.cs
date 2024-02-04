using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> OnHealthChange;
    [SerializeField] private int _max;

    private int _current;

    private void Start()
    {
        _current = _max;
        OnHealthChange?.Invoke(_current, _max);
    }

    public void Add(int value)
    {
        if (value <= 0)
            return;

        if (value + _current > _max)
            _current = _max;
        else
            _current += value;

        OnHealthChange?.Invoke(_current, _max);
    }

    public void Substract(int value)
    {
        if (value <= 0)
            return;

        if (value > _current)
            _current = 0;
        else
            _current -= value;

        if(_current <= 0)
            Die();

        OnHealthChange?.Invoke(_current, _max);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}