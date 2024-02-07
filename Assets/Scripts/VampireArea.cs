using System.Collections;
using UnityEngine;

public class VampireArea : MonoBehaviour
{
    [SerializeField] private float _healthPerSecond = 0.5f;
    [SerializeField] private Health _selfHealth;
    [SerializeField] private float _radius = 3;
    [SerializeField] private LayerMask _mask;

    private WaitForSeconds _activeTime = new WaitForSeconds(6);

    private void OnEnable()
    {
        StartCoroutine(DelayedDisable());
        StartCoroutine(SuckHealth());
    }

    private IEnumerator SuckHealth()
    {
        Collider2D[] victims;
        float timeTick = 0.1f;

        WaitForSeconds _delay = new WaitForSeconds(timeTick);
        float suckFactor = _healthPerSecond * timeTick;

        while (gameObject.activeSelf)
        {
            victims = Physics2D.OverlapCircleAll(transform.position, _radius, _mask);

            foreach (Collider2D victim in victims)
            {
                if (victim.TryGetComponent(out Health health))
                {
                    health.TakeDamage(suckFactor);
                    _selfHealth.TakeHealth(suckFactor);
                }
            }

            yield return _delay;
        }
    }

    private IEnumerator DelayedDisable()
    {
        yield return _activeTime;
        gameObject.SetActive(false);
    }
}