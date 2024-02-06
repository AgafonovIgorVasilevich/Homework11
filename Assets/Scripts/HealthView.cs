using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnChangeHealth += Show;
    }

    private void OnDisable()
    {
        _health.OnChangeHealth -= Show;
    }

    public abstract void Show(float current, float max);
}