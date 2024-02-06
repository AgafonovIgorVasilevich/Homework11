using System.Collections;
using UnityEngine;

public class VampireArea : MonoBehaviour
{
    [SerializeField] private float _activeTime = 3;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Health _selfHealth;
    [SerializeField] private float _radius = 3;

    private Collider2D[] _targets;

    private void OnEnable()
    {
        StartCoroutine(DelayedDisable());
    }

    private void Update()
    {
        _targets = Physics2D.OverlapCircleAll(transform.position, _radius);

        if (_targets.Length > 0)
            SuckHealth();
    }

    private void SuckHealth()
    {
        foreach (Collider2D target in _targets)
        {
            if (target.TryGetComponent(out Health health))
            {
                if (health == _selfHealth)
                    continue;

                health.TakeDamage(_speed * Time.deltaTime);
                _selfHealth.TakeHealth(_speed * Time.deltaTime);
            }
        }
    }

    private IEnumerator DelayedDisable()
    {
        float currentTime = 0;

        while (currentTime < _activeTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}