using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealt;

    private int _currentHealt;

    private void Start()
    {
        _currentHealt = _maxHealt;
    }

    public void Add(int value)
    {
        if (value <= 0)
            return;

        if (value + _currentHealt > _maxHealt)
            _currentHealt = _maxHealt;
        else
            _currentHealt += value;

        print($"{transform.name}: {_currentHealt}");
    }

    public void Substract(int value)
    {
        if (value <= 0)
            return;

        if (value > _currentHealt)
            _currentHealt = 0;
        else
            _currentHealt -= value;

        if (_currentHealt == 0)
            Die();

        print($"{transform.name}: {_currentHealt}");
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}