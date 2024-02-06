using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class BodyPart : MonoBehaviour
{
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private bool _isReadyToDamage = true;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AttackArea attackArea))
        {
            if (_isReadyToDamage)
            {
                print(transform.name);
                _health.TakeDamage(attackArea.Damage);
                StartCoroutine(DelayBetweenHits());
            }
        }
    }

    private IEnumerator DelayBetweenHits()
    {
        _isReadyToDamage = false;
        yield return _delay;
        _isReadyToDamage = true;
    }
}